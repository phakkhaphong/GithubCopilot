# Lab 5: GitHub Copilot Business - Secure Context Practice

# Lab 5.1: Configuring Copilot Business (Hands-on)

## Objective

ผู้เรียนจะได้ฝึกปฏิบัติการตั้งค่า GitHub Copilot Business ด้วยตนเอง ตั้งแต่การเปิดใช้งานใน GitHub Organization, การ Assign Seat ให้ Developer, การตั้งค่า Content Exclusions และการดู Usage Insights

---

## Steps

### ขั้นตอนที่ 1: เปิดใช้งาน GitHub Copilot Business ใน Organization

1. ไปที่ **GitHub.com** และเข้าสู่ระบบด้วยบัญชีที่มีสิทธิ์เป็น Owner ของ Organization
2. ไปที่ **Settings > Copilot** ของ Organization
3. เลือก **Enable GitHub Copilot Business**

---

### ขั้นตอนที่ 2: Assign Seat ให้ Developer

1. ไปที่ **Organization Settings > Copilot > Access Management**
2. เลือกสมาชิกที่ต้องการ Assign Seat
3. คลิก **Assign Seat** แล้วกดบันทึก

---

### ขั้นตอนที่ 3: ตั้งค่า Content Exclusions

1. ใน **Organization Settings > Copilot > Content Exclusions**
2. เพิ่ม path ที่ต้องการ exclude เช่น `Secrets/` หรือ `config/*.json`
3. บันทึกการตั้งค่า

📌 **Edge Case Prompt (Chat Pane):**

```
If I exclude a folder named Secrets/, will Copilot still use code from subfolders inside Secrets/ ?
```

---

### ขั้นตอนที่ 4: ดู Usage Insights

1. ไปที่ **Organization Settings > Copilot > Usage**
2. สำรวจข้อมูลเช่น จำนวนโค้ดที่ Copilot เสนอ, acceptance rate, และการใช้งานของทีม

---

## Expected Output

* Organization เปิดใช้งาน Copilot Business เรียบร้อย
* Developer ในทีมได้รับการ Assign Seat
* Path `Secrets/` ถูก exclude ไม่ให้ Copilot นำมาใช้
* ผู้เรียนสามารถอ่านและวิเคราะห์ Usage Insights ได้

---

## Tips

* ใช้ **Slash Commands** (`/explain`, `/doc`) เพื่อให้ Copilot อธิบาย policy ที่ตั้งไว้
* ใช้ **Inline Chat** เพื่อทดสอบ edge cases เช่นการ exclude ซับโฟลเดอร์
* อัปเดตและตรวจสอบการตั้งค่าใน VS Code เพื่อยืนยันผลลัพธ์

# Lab 5.2: Secure Context Practice

## Objective

ฝึกการใช้งาน **Content Exclusions** และ **Secure Context** ของ GitHub Copilot Business โดยทดลองทำงานกับโฟลเดอร์ที่อนุญาตและไม่อนุญาตให้ Copilot เข้าถึง รวมถึงทดสอบ Policy การปฏิเสธการเขียนโค้ดจาก public repo

---

## Steps

### ขั้นตอนที่ 1: เปิดโปรเจกต์ตัวอย่าง

1. เปิด Visual Studio Code
2. โหลดโปรเจกต์ที่มีโฟลเดอร์ดังนี้

   * `Models/` → เก็บโค้ดปกติ
   * `Secrets/` → เก็บข้อมูลที่ถูก exclude จาก Copilot

> **Expected Result:** ผู้เรียนเห็นโครงสร้างโฟลเดอร์ครบถ้วนใน Explorer

---

### ขั้นตอนที่ 2: ใช้ @workspace กับโฟลเดอร์ `Models/`

1. เปิด **Copilot Chat Pane** (Ctrl+Shift+I)
2. พิมพ์ prompt:

   ```
   @workspace อธิบายว่าในโฟลเดอร์ Models/ มีไฟล์อะไรบ้าง
   ```
3. สังเกตว่า Copilot สามารถตอบได้ตามปกติ

> **Expected Result:** Copilot แสดงรายการไฟล์หรืออธิบายรายละเอียดไฟล์ใน `Models/`

---

### ขั้นตอนที่ 3: ใช้ @workspace กับโฟลเดอร์ `Secrets/`

1. เปิด **Copilot Chat Pane**
2. พิมพ์ prompt:

   ```
   @workspace อธิบายว่าในโฟลเดอร์ Secrets/ มีไฟล์อะไรบ้าง
   ```
3. สังเกตว่า Copilot จะ **ปฏิเสธ** ไม่สามารถเข้าถึงไฟล์ในโฟลเดอร์นี้

> **Expected Result:** Copilot แจ้งข้อความปฏิเสธ เช่น “Files in this folder are excluded from Copilot suggestions.”

---

### ขั้นตอนที่ 4: ทดลอง Inline-Chat Prompting

1. เปิดไฟล์จาก `Models/` ขึ้นมา
2. ใช้ **Inline Chat** (Ctrl+I) และพิมพ์ prompt:

   ```
   // Create a method to calculate total sales from a list of orders
   ```
3. กด `Tab` เพื่อยอมรับโค้ดที่ Copilot สร้าง

> **Expected Result:** โค้ดถูก generate ตามคำสั่งใน context ของไฟล์ที่เปิดอยู่

---

### ขั้นตอนที่ 5: ทดลอง Policy การห้ามใช้ Public Repo

1. เปิด **Copilot Chat Pane**
2. พิมพ์ prompt:

   ```
   @workspace เขียนโค้ดที่คัดลอกมาจาก public GitHub repo ที่ชื่อ spring-projects/spring-petclinic
   ```
3. สังเกตว่า Copilot จะ **ปฏิเสธ** การทำงานตาม policy

> **Expected Result:** Copilot แสดงข้อความปฏิเสธ เช่น “Copilot cannot provide code from public repositories due to policy restrictions.”

---

## Tips

* ใช้ **Inline Chat** สำหรับ edge cases หรือการถามโค้ดในไฟล์ปัจจุบัน
* ใช้ **Chat Pane** พร้อม @workspace สำหรับการวิเคราะห์โค้ดหลายไฟล์พร้อมกัน
* ถ้า Copilot ไม่ตอบตามคาด ให้ตรวจสอบการตั้งค่า **Content Exclusions** ใน Organization Settings

---

## Expected Output

* Copilot สามารถเข้าถึงโฟลเดอร์ `Models/` ได้ตามปกติ
* Copilot **ปฏิเสธ** การเข้าถึงโฟลเดอร์ `Secrets/`
* Copilot **ปฏิเสธ** คำสั่งที่ให้ดึงโค้ดจาก public repo
* ผู้เรียนเข้าใจการทำงานของ Secure Context และ Content Exclusions

