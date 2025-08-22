# GitHub Copilot Prompt & Slash Command Cheat Sheet (C# / ASP.NET Core)

## 1. หลักการเขียน Prompt (Prompt Engineering Principles)
- **Clarity**: ระบุสิ่งที่ต้องการให้ชัดเจน
- **Context**: เปิดไฟล์หรือใส่โค้ดที่เกี่ยวข้อง เพื่อให้ Copilot เข้าใจบริบท
- **Conciseness**: กระชับแต่ครบถ้วน
- **Iterate**: ลองปรับ Prompt หลายรอบ
- **Layered Prompts**: แตกโจทย์ใหญ่เป็นหลายคำสั่งย่อย

---

## 2. ประเภทของ Prompt ที่ใช้ได้
| ประเภท | คำอธิบาย | ตัวอย่าง (C#) |
|--------|-----------|--------------|
| **Comment-to-Code** | เขียนคอมเมนต์แล้วให้ Copilot สร้างโค้ด | `// Create a C# method to calculate VAT for a price` |
| **Direct Question** | ถามตรง ๆ เกี่ยวกับโค้ด | `@workspace Explain how data flows from controller to service` |
| **Modification Request** | ขอให้แก้โค้ด | `Refactor this method to use async/await` |
| **Exploration** | ขอไอเดีย | `Suggest design patterns for an e-commerce checkout service in C#` |

---

## 3. Slash Commands ที่ใช้บ่อย
| คำสั่ง | การใช้งาน | ตัวอย่าง |
|--------|-----------|----------|
| `/explain` | อธิบายโค้ดที่เลือก | เลือก `LINQ` query → `/explain` |
| `/fix` | แก้ข้อผิดพลาด | เลือกเมธอดที่ error → `/fix` |
| `/doc` | สร้าง XML documentation | เลือกเมธอด `CalculateTotal` → `/doc` |
| `/tests` | สร้าง Unit Tests ให้ไฟล์ปัจจุบัน | เปิด `ProductService.cs` → `/tests` |
| `/new` | สร้างไฟล์/คลาสใหม่ | `/new ProductsController with CRUD actions` |

---

## 4. ตัวอย่าง Prompt สำหรับ ASP.NET Core Web API
1. **สร้าง Controller ใหม่**
```
/new Create a C# ASP.NET Core API controller named OrdersController with endpoints for CRUD using OrderService
```
2. **เพิ่ม Unit Test สำหรับ Edge Case**
```
Add an xUnit test for GetProductById method to return null when the product is not found
```
3. **Refactor โค้ด**
```
Refactor this method to use pattern matching and guard clauses in C#
```
4. **อธิบายโค้ดทั้งโปรเจกต์**
```
@workspace Summarize the responsibilities of each class in the Services folder
```

---

## 5. Tips
- ใช้ **Multiple Suggestions** (`Alt+]`) เพื่อดูตัวเลือกอื่น
- เพิ่ม **ข้อมูลเชิงธุรกิจ** ใน Prompt เช่น “ใช้ Decimal แทน Double สำหรับราคา”
- สำหรับโค้ดซับซ้อน ให้ใช้ `/explain` ก่อนแล้วค่อย `/fix` หรือ `/refactor`
