# Lab 01: First Contact with GitHub Copilot

## Objective

ทำความคุ้นเคยกับ GitHub Copilot โดยใช้ฟีเจอร์ **Ghost Text** ทั้งในรูปแบบบรรทัดเดียว (inline suggestion) และเป็น block ของโค้ด พร้อมฝึกเทคนิคการเขียน Prompt Engineering เบื้องต้นสำหรับภาษา C#

---

## Steps

### 1. สร้างโปรเจกต์ Console Application ใหม่

1. เปิด **Visual Studio Code** และสร้างโฟลเดอร์ใหม่ชื่อ `FirstContact`
2. เปิด Terminal และรันคำสั่ง:

   ```bash
   dotnet new console -n FirstContact
   cd FirstContact
   code .
   ```

---

### 2. ทดลอง Ghost Text แบบบรรทัดเดียว (Inline Suggestion)

1. เปิดไฟล์ `Program.cs`
2. พิมพ์:

   ```csharp
   Console.Write
   ```
3. รอให้ GitHub Copilot แสดง Ghost Text เสนอการเติมโค้ด
4. กด `Tab` เพื่อยอมรับ หรือ `Esc` เพื่อปฏิเสธ

---

### 3. ทดลอง Ghost Text แบบเป็น Block

1. ใน `Program.cs` เขียนคอมเมนต์:

   ```csharp
   // Create a function that takes a name and prints a greeting
   ```
2. รอให้ Copilot เสนอ Block ของโค้ดทั้งฟังก์ชัน
3. กด `Tab` เพื่อยอมรับโค้ดทั้งหมด

---

### 4. เรียกใช้เมธอดที่ Copilot สร้างใน `Main()`

```csharp
Greet("John");
```

---

### 5. รันโปรแกรม

```bash
dotnet run
```

Expected Output:

```
Hello, John!
```

---

## Tips & Prompt Engineering Practice

* ลองเปลี่ยนภาษาของคอมเมนต์เป็นภาษาไทย เช่น:

  ```csharp
  // สร้างฟังก์ชันที่รับชื่อและแสดงข้อความทักทาย
  ```
* ใช้ปุ่ม `Alt + ]` เพื่อดูคำแนะนำอื่นๆ จาก Copilot
* ทดลองปรับความละเอียดของ Prompt:

  * Prompt สั้น: `// Print greeting`
  * Prompt ยาวและละเอียด: `// Create a public static method called Greet that accepts a string parameter name and prints "Hello, <name>!" to the console`
* สังเกตความแตกต่างของโค้ดที่ได้จาก Prompt แบบต่างๆ

---

## เวลาในการทำ Lab

ประมาณ **25 นาที**
