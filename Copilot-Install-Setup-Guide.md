# คู่มือการติดตั้งและตั้งค่า GitHub Copilot สำหรับ C# Developer (VS Code)

## 1. ข้อกำหนดเบื้องต้น (Prerequisites)
- บัญชี **GitHub** (Personal, Pro, หรือ Business)
- การสมัครใช้งาน **GitHub Copilot** ([Copilot Subscription](https://github.com/features/copilot))
- ติดตั้ง **Visual Studio Code** เวอร์ชันล่าสุด ([ดาวน์โหลด](https://code.visualstudio.com/))
- ติดตั้ง **.NET SDK** (แนะนำ .NET 8) ([ดาวน์โหลด](https://dotnet.microsoft.com/download))
- ติดตั้ง **C# Dev Kit Extension** และ **C# extension** จาก Microsoft ใน VS Code

---

## 2. การเปิดใช้งาน GitHub Copilot บน GitHub.com
1. **เข้าสู่ระบบ GitHub**
   - ไปที่ [https://github.com/login](https://github.com/login) และเข้าสู่ระบบด้วยบัญชีของคุณ

2. **สมัครใช้งาน Copilot**
   - ไปที่ [GitHub Copilot Pricing](https://github.com/features/copilot)  
   - คลิก **Start my free trial** หรือ **Subscribe** (เลือกแผนที่เหมาะสม)
   - กรอกข้อมูลการชำระเงิน (ถ้ามี)

3. **ตรวจสอบการเปิดใช้งาน**
   - ไปที่ **Settings** → **Copilot** ในบัญชี GitHub ของคุณ  
   - ตรวจสอบว่ามีข้อความว่า “Your Copilot subscription is active”

---

## 3. การติดตั้ง GitHub Copilot Extension ใน VS Code
1. เปิด **VS Code**
2. ไปที่ **Extensions Marketplace** (`Ctrl+Shift+X`)
3. ค้นหาและติดตั้ง:
   - **GitHub Copilot** (โดย GitHub)
   - **GitHub Copilot Chat** (สำหรับการสนทนา/สั่งงาน AI)
4. เมื่อติดตั้งเสร็จแล้ว ไอคอน Copilot จะปรากฏที่แถบด้านข้าง (Activity Bar)

---

## 4. การเชื่อมต่อ VS Code กับบัญชี GitHub
1. หลังติดตั้ง Extension ครั้งแรก VS Code จะถามให้คุณ **Sign in with GitHub**
2. คลิก **Sign in** → จะเปิดเบราว์เซอร์เพื่อยืนยันสิทธิ์
3. กด **Authorize Visual Studio Code**
4. กลับมาที่ VS Code รอจนขึ้นข้อความยืนยันว่าลงชื่อเข้าใช้เรียบร้อย

---

## 5. การตั้งค่า GitHub Copilot สำหรับ C#
1. เปิด **Command Palette** (`Ctrl+Shift+P`)
2. พิมพ์และเลือก `Copilot: Enable`
3. ไปที่ **Settings** (`Ctrl+,`) ค้นหา **Copilot**
4. ตั้งค่า:
   - **Editor: Inline Suggest** → เปิด (On)
   - **Copilot: Enable** → เลือก “For all languages” หรือ “For C# only”
5. ติดตั้ง **C# Dev Kit** เพื่อใช้ฟีเจอร์ IntelliSense + Copilot ได้อย่างเต็มประสิทธิภาพ

---

## 6. ทดสอบใช้งานกับ C#
1. สร้างโฟลเดอร์โปรเจกต์ใหม่:
   ```bash
   mkdir FirstContact
   cd FirstContact
   dotnet new console -n FirstContact
   cd FirstContact
   code .
   ```
2. เปิดไฟล์ `Program.cs` แล้วพิมพ์คอมเมนต์ เช่น:
   ```csharp
   // Create a function that takes a name and prints "Hello, {name}!"
   ```
   รอให้ Copilot แสดง **Ghost Text** แล้วกด `Tab` เพื่อยอมรับโค้ด

---

## 7. การใช้งาน Copilot Chat สำหรับ C#
- เปิด **Chat View** (ไอคอน Copilot ที่แถบซ้าย) หรือกด `Ctrl+I` เพื่อใช้ **Inline Chat**
- ตัวอย่างการสั่งงาน:
  - `Explain how this LINQ query works`
  - `/tests Generate xUnit tests for ProductService.cs`
  - `/doc Add XML documentation for all public methods in this class`

---

## 8. ปรับแต่งการทำงาน
- **ปิด/เปิด ชั่วคราว**: กดที่ไอคอน Copilot มุมขวาล่างของ VS Code
- **ดูคำแนะนำหลายแบบ**: กด `Alt + ]` (Windows) หรือ `Option + ]` (Mac)
- **กำหนดให้ใช้เฉพาะบางไฟล์/โฟลเดอร์**: แก้ไฟล์ `.editorconfig` หรือใช้ Content Exclusion ใน GitHub Copilot Business

---

## 9. แหล่งข้อมูลเพิ่มเติม
- [GitHub Copilot Docs](https://docs.github.com/copilot)
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [.NET Documentation](https://learn.microsoft.com/dotnet/)
