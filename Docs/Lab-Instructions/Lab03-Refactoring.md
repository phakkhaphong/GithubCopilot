# Lab 03: Code Cleanup & Documentation (40 นาที)

> **โหมดปฏิบัติการ:** คำสั่งแบบขั้นตอน (ไม่มีการโต้ตอบ) — ผู้เรียนทำตามเอกสารนี้จนจบ

---

## วัตถุประสงค์ (Objectives)

หลังจบแลบนี้ ผู้เรียนจะสามารถ:

1. ระบุและแก้ปัญหา *code smell* ที่พบบ่อย (long method, magic numbers, missing validation, mixed responsibilities)
2. Refactor เมธอดให้สอดคล้องหลักการ **SOLID** และ *clean code*
3. สร้างและปรับปรุง **XML Documentation** (triple-slash `///`) โดยใช้ **Copilot Slash Commands**
4. ประยุกต์หลักการ **Prompt Engineering** เพื่อควบคุมผลลัพธ์จาก Copilot ให้ได้คุณภาพ

---

## สภาพแวดล้อมและไฟล์ที่ใช้ (Setup)

* เปิดโซลูชัน: `Lab03-Refactoring-Start/Refactoring.sln`
* ไฟล์หลัก: `BadCode.cs`
* IDE: Visual Studio Code (แนะนำ) หรือ Visual Studio 2022+
* Extensions แนะนำ: GitHub Copilot, GitHub Copilot Chat, C# Dev Kit (ถ้าใช้ VS Code)

> **หมายเหตุ:** ให้เปิดไฟล์ที่เกี่ยวข้องทั้งหมด (อย่างน้อย `BadCode.cs`) เพื่อให้ Copilot เห็นบริบท

---

## ช่วงเวลาและแผนงาน (Timebox — 40 นาที)

* (05 นาที) วิเคราะห์ *code smell* และกำหนด Acceptance Criteria
* (20 นาที) Refactor ตามหลัก SOLID + เพิ่มการทดสอบเชิงพฤติกรรมเล็กน้อย (optional)
* (10 นาที) สร้าง/ปรับปรุง **XML Documentation** ด้วย `/doc` และตรวจแก้
* (05 นาที) ตรวจคุณภาพโค้ด + สรุปผล + เตรียมส่งงาน

---

## เกณฑ์ยอมรับ (Acceptance Criteria)

**โค้ดหลังปรับปรุงต้อง:**

* แยกความรับผิดชอบชัดเจน (SRP) — ไม่มีเมธอดยาวเกินความจำเป็น และไม่มีการทำงานหลายอย่างในเมธอดเดียว
* ไม่มี *magic numbers/strings* — ใช้ `const`, `readonly`, หรือ `enum`
* มีการตรวจสอบอินพุตสำคัญ (null/empty/range) พร้อมข้อความข้อผิดพลาดที่เข้าใจง่าย
* มี **XML Documentation** ครบถ้วนใน public class/method/parameter/return (รวม *exception* ที่อาจถูก throw)
* ผ่านการคอมไพล์และรันได้โดยไม่ error/warning ที่สำคัญ

> **หลักฐานผลลัพธ์ที่ต้องส่ง:** สกรีนช็อต `Build succeeded` และตัวอย่าง XML Doc ที่เสร็จสมบูรณ์ 1 เมธอด

---

## หลักการ Prompt Engineering (ใช้งานจริงในแลบนี้)

### 1) ชัดเจน (Clarity)

* โฟกัส “งานเดียว” ต่อพรอมป์ พร้อมเงื่อนไขและผลลัพธ์คาดหวัง
* **ตัวอย่างพรอมป์:**

  * *Inline Chat ในบรรทัดเมธอดยาว:*
    `Refactor this method to follow SOLID and SRP. Keep public API. Extract validation, configuration, and IO concerns into separate methods or classes. Preserve behavior. Add parameter guards with ArgumentException.`

### 2) ละเอียด (Detail)

* ระบุข้อกำหนด/เวอร์ชัน/ตัวอย่าง input-output ให้ชัด
* **ตัวอย่าง:**

  * `Target C# 12, .NET 8. Validate null/empty for 'path' and 'customerId'. Replace magic strings with constants. Provide unit-testable pure functions where possible.`

### 3) กระชับ (Concise)

* สั้น กระชับ อ่านง่าย — ถ้าผลยังไม่โดนใจ ให้ *iterate* เพิ่มรายละเอียดทีละชั้นแทนเขียนยาวตั้งแต่แรก

### 4) มีบริบท (Contextual)

* อ้างชื่อไฟล์/คลาส/เมธอดที่เกี่ยวข้อง และเปิดไฟล์ใน IDE
* **ตัวอย่าง:** `In BadCode.cs, focus on Process(). Do not change external consumers.`

### ไล่จากง่าย → ละเอียด (Layered Prompts)

1. High-level: `Identify code smells in Process() and propose a refactoring plan following SOLID.`
2. เพิ่มเงื่อนไข: `Extract parsing to a separate class IOrderParser; inject via constructor.`
3. เพิ่มตัวอย่าง: `Given input 'A,100;B,200', expect List<Order> with 2 items. Handle malformed records gracefully.`
4. เพิ่ม Acceptance: `No behavioral change; public signatures stable; 100% build; add XML docs stubs.`

### Best Practices

* เปิดไฟล์ที่เกี่ยวข้อง, ใช้ชื่อไฟล์/สัญญา (interfaces), ใส่คอมเมนต์นำทาง
* แยกงานยากเป็นชุด *Layered Prompt* และ refine จากผลลัพธ์
* ทำ Feedback Loop ภายในทีม: commit เป็นช่วง ๆ พร้อมข้อความสื่อความ

---

## ขั้นตอนปฏิบัติ (Step-by-Step)

### Part A — วิเคราะห์ปัญหา (05 นาที)

1. เปิด `BadCode.cs` และเลือกเมธอดที่ “เขียนไม่ดี” (เช่น `Process`, `Handle`, หรือเมธอดที่ยาวเกิน 30–40 บรรทัด)
2. ใช้ **Inline Chat**: `/explain` หรือพิมพ์ว่า `Explain what this method does and list the code smells with short justifications.`
3. จดรายการ *code smells* และร่างแผนการแก้ (เช่น แยกความรับผิดชอบ, แทนที่ magic numbers, เพิ่ม validation, ใช้ DI)

### Part B — Refactor ตามหลัก SOLID (20 นาที)

> **เป้าหมาย:** คงพฤติกรรมเดิม แต่โค้ดอ่านง่าย ทดสอบง่าย และขยายได้

1. ที่บรรทัดเมธอดเป้าหมาย เปิด **Inline Chat** แล้วใช้พรอมป์:

   * `Refactor this method to follow SOLID principles (SRP, OCP, DIP). Keep current public API. Extract parsing, validation, and IO. Replace magic constants with named constants or enums. Add guard clauses.`
2. หาก Copilot เสนอหลายทางเลือก ให้เลือก *multiple suggestions* และเปรียบเทียบ; รักษา signature เดิมเพื่อไม่ให้กระทบผู้ใช้ภายนอก
3. แยกคลาส/อินเตอร์เฟซที่จำเป็น (ตัวอย่าง):

   * `IOrderParser` + `CsvOrderParser`
   * `IPriceCalculator`
   * `ILogger` (หรือใช้ `ILogger<T>` มาตรฐาน)
4. นำ *dependency* เข้าผ่าน **Constructor Injection** (DIP)
5. แทนที่ *magic values* ด้วย `const`, `readonly`, `enum`, หรือ `Options` pattern
6. เพิ่ม *parameter validation* ด้วย `ArgumentNullException.ThrowIfNull(...)`, `ArgumentException`, หรือ `Guard` methods
7. ตรวจให้แน่ใจว่าฟังก์ชันบริสุทธิ์ (pure) แยกจาก IO เพื่อให้ทดสอบง่าย
8. บันทึกไฟล์และ **Build** โครงการ; แก้ข้อผิดพลาดที่เกิดขึ้นจน `Build succeeded`

> **พรอมป์เสริม (เมื่อผลยังไม่ดี):**
> `Rewrite using modern C# features (pattern matching, switch expressions, 'using var', collection expressions). Keep behavior and exceptions.`

### Part C — สร้าง XML Documentation (10 นาที)

1. วางเคอร์เซอร์ที่ชื่อคลาส/เมธอดสำคัญ → ใช้ **Slash Command**: `/doc`
2. ให้ Copilot สร้าง XML Doc (summary/param/returns/exception)
3. ตรวจแก้ภาษา/ความชัดเจน/ตัวอย่างการใช้งาน (*usage examples*) ให้เหมาะกับโปรเจกต์
4. ตรวจให้แน่ใจว่า XML Doc ครอบคลุม public API ที่เปิดใช้งาน

> **พรอมป์ตัวอย่าง:**
> `/doc Generate XML documentation in Thai with clear summary, param/returns, and when exceptions are thrown. Include usage example with valid and invalid input.`

### Part D — ตรวจคุณภาพและสรุปผล (05 นาที)

1. ตรวจรายการ **Acceptance Criteria** ว่าครบทุกข้อ
2. รันโปรแกรม/ทดสอบฟังก์ชันหลัก (หากมีตัวอย่างอินพุต ให้ทดสอบอย่างน้อย 2–3 เคส รวมเคสผิดรูปแบบ)
3. เก็บภาพหน้าจอผล `Build succeeded` และตัวอย่าง XML Doc ที่สมบูรณ์ 1 เมธอด

---

## ตัวอย่างพรอมป์พร้อมเงื่อนไข (Prompt Snippets)

* *วิเคราะห์โค้ด*:
  `List code smells in this method with brief reasons and a SOLID-based refactoring plan.`
* *แยกความรับผิดชอบ*:
  `Extract parsing logic to IOrderParser and inject via constructor. Keep public signature. Provide a minimal implementation and usage example.`
* *ปรับปรุงประสิทธิภาพ*:
  `Refactor to reduce allocations and avoid repeated regex parsing. Prefer Span/ReadOnlySpan where safe. Preserve behavior.`
* *จัดการข้อผิดพลาด*:
  `Add guard clauses and meaningful exceptions for invalid input or missing resources. Document exceptions in XML comments.`
* *เอกสารภาษาไทย*:
  `/doc Create concise Thai XML docs, include <remarks> with gotchas and edge cases.`

---

## ผลลัพธ์ที่คาดหวัง (Expected Output)

* โค้ดอ่านง่าย สั้นลง และแบ่งความรับผิดชอบชัดเจน
* ไม่มี *magic numbers/strings* ที่ไม่มีชื่ออธิบาย
* มี **XML Documentation** ครบ (summary/params/returns/exception/remarks)
* โค้ดคอมไพล์และรันสำเร็จ (แคปหน้าจอยืนยัน)

---

## เช็กลิสต์ก่อนส่ง (Submission Checklist)

* [ ] Build ผ่านโดยไม่มี error สำคัญ
* [ ] ยืนยัน SRP และการฉีดพึ่งพา (DI) ใช้งานได้
* [ ] แทนที่ magic values แล้ว
* [ ] มี XML Doc ครบใน public API สำคัญ
* [ ] แนบสกรีนช็อตผล Build และตัวอย่าง XML Doc 1 เมธอด

---

## ภาคผนวก A — โครงร่างรีแฟกเตอร์แนะนำ (Guided Skeleton)

* `BadCode.Process()` → แยกเป็น:

  * `IOrderParser.Parse(string raw) : IReadOnlyList<Order>`
  * `IPriceCalculator.Calculate(IReadOnlyList<Order>) : decimal`
  * `IOutputWriter.Write(Result result)`
* คลาสหลักรับ `IOrderParser`, `IPriceCalculator`, `IOutputWriter` ผ่าน ctor
* เพิ่ม `OrderValidation.Validate(Order)` สำหรับตรวจก่อนคิดราคา

---

## ภาคผนวก B — หมายเหตุการใช้ Copilot อย่างปลอดภัย

* ตรวจทานโค้ดทุกครั้ง (security, performance, licensing)
* ระบุข้อกำหนดในพรอมป์ให้ครบ (ภาษา, เวอร์ชัน, เฟรมเวิร์ก)
* เก็บ commit เป็นช่วง ๆ เพื่อย้อนกลับได้ง่าย

