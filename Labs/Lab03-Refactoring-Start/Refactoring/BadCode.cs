// INTENTIONALLY BAD CODE for refactoring lab.
using System;
using System.Collections.Generic;

public enum ReportStatus
{
    Ok,
    NotOk
}

/// <summary>
/// คลาสที่เก็บตัวเลือกและข้อความสถานะต่างๆ สำหรับการสร้างรายงาน
/// </summary>
/// <remarks>
/// คลาสนี้ใช้ในการกำหนดค่าข้อความที่จะแสดงในรายงานตามสถานะต่างๆ
/// เช่น สถานะปกติ สถานะมีปัญหา หรือกรณีที่ข้อมูลเป็นค่าว่างหรือ null
/// </remarks>
public class ReportOptions
{
    private string _okStatusMessage = "ok";
    private string _notOkStatusMessage = "not ok";
    public string NotOkStatusMessage { get; set; } = "not ok";
    public string EmptyMessage { get; set; } = "EMPTY";
    public string NullMessage { get; set; } = "NULL";
}

public class ReportGenerator {
    private readonly ReportOptions _options;
    private readonly IConsoleOutput _output;
    private readonly INumberProcessor _numberProcessor;
    private readonly IInputValidator _validator;
    
    public ReportGenerator() : this(new ConsoleOutput(), new NumberProcessor(), new InputValidator(), new ReportOptions()) { }
    
    public ReportGenerator(IConsoleOutput output, INumberProcessor numberProcessor, IInputValidator validator, ReportOptions options = null) {
        _output = output;
        _numberProcessor = numberProcessor;
        _validator = validator;
        _options = options ?? new ReportOptions();
    }
    
    /// <summary>
    /// ประมวลผลและแสดงรายงานตามข้อมูลที่รับเข้ามา
    /// </summary>
    /// <param name="nums">ลิสต์ของตัวเลขที่ต้องการประมวลผล</param>
    /// <param name="name">ชื่อผู้ใช้</param>
    /// <param name="debug">แสดงข้อมูล debug หรือไม่</param>
    /// <exception cref="ArgumentNullException">nums หรือ name เป็น null</exception>
    /// <exception cref="ArgumentException">nums ว่างเปล่า หรือ name ไม่ถูกต้อง</exception>
    /// <exception cref="InvalidOperationException">Resource ที่จำเป็นหายไป</exception>
    public void DoAllStuff(List<int> nums, string name, bool debug) {
        if (_output == null) throw new InvalidOperationException("Console output resource is missing.");
        if (_numberProcessor == null) throw new InvalidOperationException("Number processor resource is missing.");
        if (_validator == null) throw new InvalidOperationException("Input validator resource is missing.");
        if (_options == null) throw new InvalidOperationException("Report options resource is missing.");

        if (nums == null)
            throw new ArgumentNullException(nameof(nums), "Input list must not be null.");
        if (nums.Count == 0)
            throw new ArgumentException("Input list must not be empty.", nameof(nums));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name must not be null or whitespace.", nameof(name));

        var average = _numberProcessor.CalculateAverage(nums);

        if (debug) {
            _output.WriteLine($"AVG={average}");
        }

        if (_validator.IsValidName(name)) {
            _output.WriteLine($"User:{name}");
        }

        // สมมติว่ามี ThresholdValue และ OkStatusMessage ใน _options
        var thresholdProp = _options.GetType().GetProperty("ThresholdValue");
        var okStatusProp = _options.GetType().GetProperty("OkStatusMessage");
        var notOkStatusProp = _options.GetType().GetProperty("NotOkStatusMessage");
        if (thresholdProp == null || okStatusProp == null || notOkStatusProp == null)
            throw new InvalidOperationException("ReportOptions missing required properties.");

        double threshold = (double)(thresholdProp.GetValue(_options) ?? 0.0);
        string okStatus = (string)(okStatusProp.GetValue(_options) ?? "ok");
        string notOkStatus = (string)(notOkStatusProp.GetValue(_options) ?? "not ok");

        var status = average > threshold ? okStatus : notOkStatus;
        _output.WriteLine(status);
    }
}

public interface IConsoleOutput {
    void WriteLine(string message);
}

public interface INumberProcessor {
    double CalculateAverage(List<int> numbers);
}

public interface IInputValidator {
    bool IsValidName(string name);
}

public class ConsoleOutput : IConsoleOutput {
    public void WriteLine(string message) {
        Console.WriteLine(message);
    }
}

public class NumberProcessor : INumberProcessor {
    /// <summary>
    /// คำนวณค่าเฉลี่ยของลิสต์ตัวเลข
    /// </summary>
    /// <param name="numbers">ลิสต์ของตัวเลข</param>
    /// <returns>ค่าเฉลี่ย</returns>
    /// <exception cref="ArgumentNullException">numbers เป็น null</exception>
    /// <exception cref="ArgumentException">numbers ว่างเปล่า</exception>
    public double CalculateAverage(List<int> numbers) {
        if (numbers == null)
            throw new ArgumentNullException(nameof(numbers), "Input list must not be null.");
        if (numbers.Count == 0)
            throw new ArgumentException("Input list must not be empty.", nameof(numbers));
        var sum = 0.0;
        foreach (var number in numbers) {
            sum += number;
        }
        return sum / numbers.Count;
    }
}

public class InputValidator : IInputValidator {
    /// <summary>
    /// ตรวจสอบความถูกต้องของชื่อ
    /// </summary>
    /// <param name="name">ชื่อ</param>
    /// <returns>true ถ้าชื่อถูกต้อง</returns>
    /// <exception cref="ArgumentNullException">name เป็น null</exception>
    public bool IsValidName(string name) {
        if (name == null)
            throw new ArgumentNullException(nameof(name), "Name must not be null.");
        return !string.IsNullOrWhiteSpace(name);
    }
}
