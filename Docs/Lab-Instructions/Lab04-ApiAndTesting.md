# Lab 4.1 : API Expansion with GitHub Copilot

## Objective

เพิ่ม API Endpoint ใหม่ในโปรเจกต์ Web API โดยใช้ GitHub Copilot Chat, Inline Chat, Agents และ Prompt Engineering เพื่อให้ได้โค้ดที่ถูกต้องและใช้งานได้จริง

---

## Steps

### **ส่วนที่ 1: API Expansion**

#### 1. เปิดโปรเจกต์

* เปิด **Visual Studio Code**
* ไปที่โฟลเดอร์ `Lab04-ApiAndTesting-Start`
* เปิด Solution `WebApi.sln`
* **เครื่องมือที่ใช้:** VS Code + GitHub Copilot Extension

Prompt ตัวอย่าง (Chat Pane):

```
@workspace อธิบายโครงสร้างของโปรเจกต์นี้ให้หน่อย
```

* จุดประสงค์: เพื่อให้ Copilot วิเคราะห์โครงสร้างไฟล์ทั้งหมดและเข้าใจ Context ของโค้ดปัจจุบัน

---

#### 2. ใช้ Agent `@workspace` เพื่อวิเคราะห์โครงสร้าง

* เปิด **GitHub Copilot Chat** (กด `Ctrl+Shift+I` หรือ `Cmd+Shift+I` บน Mac)
* พิมพ์คำสั่ง:

```
@workspace list all controllers and their responsibilities
```

* จุดประสงค์: เพื่อระบุว่ามี Controller ไหนอยู่แล้วบ้างและเราควรสร้างใหม่หรือแก้ไขไฟล์ใด

---

#### 3. ใช้ `/new` เพื่อสร้าง `ProductsController`

* เปิด **Chat Pane** แล้วใช้ Slash Command

```
/new file:Controllers/ProductsController.cs
ใช้ C# ASP.NET Core Web API, สร้าง Controller ชื่อ ProductsController และ Inject IProductService
เพิ่ม endpoints: GET all, GET by id, POST, PUT, DELETE
```

* **Tips:** ใส่รายละเอียดพารามิเตอร์และรูปแบบการคืนค่าเพื่อให้ Copilot สร้างโค้ดได้ตรงความต้องการ

---

#### 4. ใช้ **Inline Chat** เพื่อปรับปรุงโค้ด

* เปิดไฟล์ `ProductsController.cs`
* เลือกเมธอดที่ Copilot สร้างมา แล้วกด `Ctrl+I` เพื่อเปิด Inline Chat
* พิมพ์:

```
/refactor เพิ่มการตรวจสอบ model state และการคืนค่า HTTP status code ที่เหมาะสม
```

---

#### 5. เพิ่ม XML Documentation

* เลือกเมธอดทั้งหมดใน `ProductsController`
* ใช้ Inline Chat:

```
/doc สร้าง XML documentation ให้เมธอดทั้งหมดเป็นภาษาอังกฤษ
```

---

#### 6. ทดสอบ API Endpoint ใหม่

* รันโปรเจกต์ (`F5` หรือ `dotnet run`)
* เปิด Swagger UI แล้วทดสอบแต่ละ Endpoint
* **Prompt ตัวอย่าง (Chat Pane):**

```
@terminal run dotnet test เพื่อรัน unit tests ทั้งหมด
```

---

## Recap ของเครื่องมือที่ใช้

| ขั้นตอน               | เครื่องมือ             | จุดประสงค์                             |
| --------------------- | ---------------------- | -------------------------------------- |
| วิเคราะห์โครงสร้าง    | Chat Pane + @workspace | เข้าใจ Context ของโปรเจกต์             |
| สร้าง Controller ใหม่ | Chat Pane + /new       | ให้ Copilot สร้างไฟล์พร้อมโค้ดเริ่มต้น |
| ปรับปรุงโค้ด          | Inline Chat            | แก้ไขและเพิ่มฟีเจอร์ภายในไฟล์          |
| สร้างเอกสาร           | Inline Chat + /doc     | เพิ่ม XML Documentation                |
| ทดสอบ                 | Terminal + @terminal   | รันและตรวจสอบ Unit Tests               |

---

## Expected Output

* ไฟล์ `ProductsController.cs` ที่มี CRUD Endpoints ครบถ้วน
* XML Documentation ครบทุกเมธอด
* API ผ่านการทดสอบใน Swagger และ Unit Tests สำเร็จ

---

## Tips

* ใช้ **Prompt Engineering**: งานเดียวต่อหนึ่งพรอมป์, ให้รายละเอียดครบ, และอธิบายให้ชัดเจน
* ใช้ **Agents** (@workspace, @terminal) เพื่อเพิ่ม Context ให้ Copilot


# Lab 4.2 : Unit Testing with GitHub Copilot

## Objective

สร้าง Unit Tests สำหรับ Service และ Controller โดยใช้ GitHub Copilot Chat, Inline Chat, Prompting for Edge Cases และ Mocking Framework เพื่อให้การทดสอบครอบคลุมทั้ง Happy Path และ Edge Cases

---

## Steps

### **ส่วนที่ 2: Unit Testing**

#### 1. สร้างโครงการทดสอบ xUnit

* ในโฟลเดอร์ `Lab04-ApiAndTesting-Start` ให้สร้างโฟลเดอร์ใหม่ชื่อ `WebApi.Tests`
* ใช้ **Chat Pane** พิมพ์:

```
/new project:xunit ในโฟลเดอร์ WebApi.Tests สำหรับทดสอบโค้ดในโปรเจกต์ WebApi
```

* จุดประสงค์: ให้ Copilot สร้างโครงสร้างโครงการทดสอบพร้อมไฟล์เริ่มต้น

---

#### 2. สร้าง Unit Tests สำหรับ `ProductService`

* เปิด **Chat Pane** และพิมพ์:

```
/tests สร้าง unit tests สำหรับคลาส ProductService ครอบคลุม CRUD methods
```

* ใช้ **Inline Chat** ในไฟล์ Test เพื่อขอให้ Copilot เพิ่มรายละเอียดการทดสอบแต่ละกรณี

---

#### 3. เพิ่ม Test Cases สำหรับ Edge Cases

* เปิดไฟล์ทดสอบของ `ProductService`
* ใช้ Inline Chat พิมพ์:

```
/tests เพิ่ม test cases สำหรับ edge cases เช่น input เป็น null, ข้อมูลไม่ถูกต้อง, id ไม่พบ
```

* จุดประสงค์: ให้การทดสอบครอบคลุมเงื่อนไขผิดปกติและการจัดการข้อผิดพลาด

---

#### 4. สร้าง Unit Tests สำหรับ `ProductsController`

* ใช้ **Chat Pane**:

```
/tests สร้าง unit tests สำหรับ ProductsController โดยใช้ Moq สำหรับ mock IProductService
```

* ใช้ **Prompting for Edge Cases**:

```
/tests เพิ่ม test case สำหรับกรณี ModelState ไม่ถูกต้อง และกรณี service คืนค่า null
```

---

#### 5. รันการทดสอบ

* เปิด Terminal และพิมพ์:

```
dotnet test
```

* หรือใช้ Chat Pane กับ Agent `@terminal`:

```
@terminal run dotnet test
```

---

## Recap ของเครื่องมือที่ใช้

| ขั้นตอน           | เครื่องมือ           | จุดประสงค์                            |
| ----------------- | -------------------- | ------------------------------------- |
| สร้างโครงการทดสอบ | Chat Pane + /new     | สร้าง xUnit Test Project              |
| เขียน Unit Tests  | Chat Pane + /tests   | ให้ Copilot สร้างการทดสอบเบื้องต้น    |
| เพิ่ม Edge Cases  | Inline Chat          | เพิ่มการทดสอบกรณีผิดปกติ              |
| Mock Service      | Chat Pane + Moq      | แยกการทดสอบ Controller ออกจาก Service |
| รันทดสอบ          | Terminal + @terminal | ตรวจสอบความถูกต้องของการทดสอบ         |

---

## Expected Output

* โค้ด Unit Tests สำหรับ `ProductService` และ `ProductsController` ครอบคลุมทั้ง Happy Path และ Edge Cases
* ใช้ Mocking Framework สำหรับการทดสอบ Controller

---

## Tips

* ใช้ Prompt เฉพาะเจาะจงเพื่อให้ได้ Test Case ที่ต้องการ
* ตรวจสอบว่า Test Method มีชื่อชัดเจนและสื่อความหมาย
* รักษาหลักการ **หนึ่งการทดสอบต่อหนึ่งพฤติกรรม** เพื่อให้การทดสอบอ่านง่ายและบำรุงรักษาง่าย
