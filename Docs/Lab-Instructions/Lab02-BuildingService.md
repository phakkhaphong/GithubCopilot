# Lab 02: Building a C# Service Class — Advanced Copilot Techniques (40 นาที)

> **Objective:** สร้าง `ProductService` พร้อม CRUD + เทคนิคใช้งาน GitHub Copilot ขั้นสูงแบบ *ไม่มีการโต้ตอบ* (ทำตามคำสั่งล้วน ๆ) เพื่อยกระดับความแม่นยำ ความเร็ว และคุณภาพโค้ด

---

## Environment & Prerequisites (เตรียม 3–5 นาที)

* VS Code + ส่วนขยาย: **C# Dev Kit**, **GitHub Copilot**, **GitHub Copilot Chat**
* .NET SDK 8+
* โครงสร้างโฟลเดอร์ (จาก ZIP หลักสูตร):

  * `Labs/Lab02-BuildingService-Start/`

    * `ProductService.sln`
    * `ProductService/Models/` (จะเพิ่ม `Product.cs`)
    * `ProductService/Services/` (จะเพิ่ม `IProductService.cs`, `ProductService.cs`)

> **หมายเหตุ:** ปิด notification อื่น ๆ และเปิดเฉพาะไฟล์ที่ใช้งาน เพื่อให้ Copilot โฟกัสคอนเท็กซ์ได้แม่นยำ

---

## งานหลักและเวลาโดยประมาณ (รวม \~40 นาที)

1. **Setup โครงการ** (5 นาที)
2. **Inline Suggestions (Ghost Text) – Inline & Block (Advance)** (10 นาที)
3. **Command Palette** (5 นาที)
4. **Inline Chat** (8 นาที)
5. **Comments‑to‑Code (Prompt Engineering ขั้นสูง)** (8 นาที)
6. **Multi‑Suggestion Pane** (4 นาที)

---

## 1) Setup โครงการ (5 นาที)

1. เปิดโฟลเดอร์ `Lab02-BuildingService-Start` และเปิด `ProductService.sln`
2. สร้างไฟล์ `Models/Product.cs` และ `Services/IProductService.cs`, `Services/ProductService.cs`
3. ตรวจสอบให้เปิดเฉพาะไฟล์ 3 ไฟล์นี้ + `Program.cs` (ถ้ามี) เพื่อกำหนดคอนเท็กซ์ให้ Copilot

> **เคล็ดลับคอนเท็กซ์:** ตั้งชื่อเมธอด/พร็อพเพอร์ตีให้สื่อความหมาย เช่น `GetByIdAsync`, `FindAsync`, `UpsertAsync`, `DeleteAsync` พร้อมคีย์เวิร์ดโดเมน เช่น `Sku`, `Category`, `IsActive`

---

## 2) Inline Suggestions (Ghost Text) — Inline & Block (Advance) (10 นาที)

**ไฟล์:** `Models/Product.cs`

### 2.1 Inline Ghost Text (ทีละบรรทัด)

พิมพ์และรอ Ghost Text ให้แสดงผล แล้วกด `Tab` เพื่อยอมรับ

```csharp
namespace ProductService.Models;

// Create a POCO for Product with validation-friendly types
public class Product
{
    // id (GUID), sku (string non-null), name, category, price (decimal),
    // stock (int), isActive (bool), createdUtc, updatedUtc (DateTime)
}
```

**สิ่งที่คาดหวัง:** Copilot เติมพร็อพเพอร์ตีครบชุด และกำหนด default/init ที่เหมาะสม (nullable annotations, `required`/`init` ถ้ารองรับ)

### 2.2 Block Suggestion (หลายบรรทัด)

ใน `Services/IProductService.cs`

```csharp
namespace ProductService.Services;
using ProductService.Models;

// Define CRUD interface with async methods and cancellation support
// Include: GetAllAsync(filter?, sort?), GetByIdAsync, CreateAsync, UpdateAsync (optimistic concurrency), DeleteAsync
```

**สิ่งที่คาดหวัง:** Copilot เสนอ block โค้ด interface ครบถ้วน รวมทั้งพารามิเตอร์ `CancellationToken` และรูปแบบคืนค่า `Task<T>` ที่เหมาะสม

> **ทิป:** ถ้า Ghost Text ยังไม่ตรงใจ ให้เพิ่มคอมเมนต์ข้อกำหนด เช่น “use C# 12 features”, “return `IReadOnlyList<Product>`” เพื่อ *บังคับสไตล์* ที่ต้องการ

---

## 3) Command Palette — (5 นาที)

เปิด **Command Palette** (Windows/Linux: `Ctrl+Shift+P`, macOS: `Cmd+Shift+P`) และรันคำสั่งต่อไปนี้แบบ *ทีละข้อ*

1. **Copilot: Explain Selected Code** — ไฮไลต์ interface ที่สร้าง แล้วสั่งอธิบาย (ใช้เพื่อรีวิวสัญญาและ error handling)
2. **Copilot: Generate Unit Tests** — เลือก `ProductService.cs` (ว่าง) เพื่อให้ Copilot สร้างโครง `xUnit`/`NUnit` เบื้องต้นสำหรับ CRUD (จะปรับต่อใน Lab อื่น)
3. **Copilot: Fix this** (หรือ **Refactor this**) — เลือกเมธอดที่ Copilot เติม แล้วยกระดับเป็น *pure function* หรือเพิ่ม *guard clauses*

> ถ้าไม่เจอคำสั่ง ให้ค้นด้วยคีย์เวิร์ด “Copilot” ใน Command Palette

---

## 4) Inline Chat — (8 นาที)

เปิด **Inline Chat** (Windows/Linux: `Ctrl+I`, macOS: `Cmd+I`) ที่จุดแทรกในไฟล์ `ProductService.cs`

### ตัวอย่าง A — เติม Logic สำหรับ GetAllAsync

Prompt (ที่บรรทัดว่างของคลาส):

```
Use repository-less in-memory list for now. Implement GetAllAsync with optional filter by Category and IsActive, support paging (skip/take), and sorting by Price descending. Use CancellationToken properly and return IReadOnlyList<Product>.
```

### ตัวอย่าง B — เติม UpdateAsync (Optimistic Concurrency)

Prompt:

```
Implement UpdateAsync with optimistic concurrency using a version field (int). If version mismatch, return a specific Result type with Conflict status. Use pattern matching and minimal allocations.
```

### ตัวอย่าง C — เติม DeleteAsync ด้วย Soft Delete

Prompt:

```
Implement DeleteAsync that performs soft delete by setting IsActive=false and UpdatedUtc=UtcNow. If not found, return NotFound. Include cancellation support.
```

> **หมายเหตุ:** ถ้าโปรเจกต์ยังไม่มี `Result` type ให้ให้ Copilot สร้าง record `Result<T>` + static factories (`Ok`, `NotFound`, `Conflict`) ในไฟล์ย่อย

---

## 5) Comments‑to‑Code — (Advance Prompt Engineering) (8 นาที)

> เทคนิค: เขียนคอมเมนต์ให้เป็น *Acceptance Criteria* + *Constraints* + *Style Guide* เพื่อควบคุมผลลัพธ์

### ตัวอย่าง 1 — CreateAsync (Validation + Idempotency)

ใน `ProductService.cs` วางคอมเมนต์เหนือเมธอด:

```csharp
// GOAL: Implement CreateAsync(Product p)
// ACCEPTANCE:
//  - Validate required fields (Sku, Name, Price>=0), trim strings
//  - Idempotent by Sku: if Sku exists -> return Result.Conflict
//  - Set CreatedUtc/UpdatedUtc=UtcNow, IsActive default true
// CONSTRAINTS:
//  - No external libs, no DB; use in-memory list
//  - CancellationToken honored at start
// STYLE:
//  - C# 12, expression-bodied where clean; use guard clauses
//  - Return Result<Product>
```

### ตัวอย่าง 2 — GetByIdAsync (Fast Path + Logging Hook)

```csharp
// Implement GetByIdAsync(Guid id)
// Acceptance: O(1) lookup via Dictionary index; if not found -> Result.NotFound
// Add optional ILogger hook (nullable) but no-op by default
// Constraints: CancellationToken, no allocations on not-found path
```

### ตัวอย่าง 3 — UpdateAsync (Partial Update via Patch Model)

```csharp
// Implement UpdateAsync(ProductPatch patch)
// Acceptance: Only update non-null properties; validate Price>=0; bump version; set UpdatedUtc
// Constraints: Thread-safe with lock; avoid LINQ overuse in hot path; honor CancellationToken
// Style: Use switch expression and with-expressions if record is used
```

ยืนยัน Ghost Text/Block ที่ Copilot เสนอ แล้วปรับจูนถ้อยคำคอมเมนต์หากผลยังไม่ตรงเกณฑ์

---

## 6) Multi‑Suggestion Pane (4 นาที)

**เป้าหมาย:** เปรียบเทียบหลาย ๆ วิธีแก้ที่ Copilot เสนอ แล้วเลือกทางที่เหมาะสมที่สุด

ขั้นตอน:

1. ที่ตำแหน่งมี Ghost Text ให้กดเปิด **Multiple Suggestions** (เช่น `Alt + ]` เพื่อวนข้อเสนอถัดไป)
2. พิจารณา *เกณฑ์เลือก*: ความถูกต้อง, ครอบคลุมเงื่อนไข, ประสิทธิภาพ (allocations/complexity), ความสอดคล้องสไตล์ทีม
3. ยอมรับตัวเลือกที่ดีที่สุดด้วย `Tab` และทดสอบ Build

> **ทิป:** เก็บ *ตัวเลือกดี ๆ* ไว้ใน *code snippet library* ของทีมเพื่อเป็นมาตรฐาน

---

## Deliverables (สิ่งที่ต้องส่งท้าย Lab)

* `Models/Product.cs` — POCO ครบถ้วน พร้อม nullability/validation-friendly types
* `Services/IProductService.cs` — สัญญา CRUD + async + cancellation + ตัวเลือก filter/sort
* `Services/ProductService.cs` — ติดตั้ง Logic ครบตาม Acceptance (Create/Read/Update/Delete)

> **ไม่จำเป็นต้องมี DB จริง** ใน Lab นี้ ใช้ in-memory collection ให้ครบ acceptance ก่อน

---

## Quality Checklist (Self‑Review)

* [ ] ทุกเมธอดมี `CancellationToken`
* [ ] ค่าที่รับ/ส่งมีชนิดเหมาะสม (`IReadOnlyList<T>`, `Result<T>`)
* [ ] มี Guard Clauses สำหรับ invalid input
* [ ] จัดการ `UtcNow` และเวอร์ชันออบเจ็กต์อย่างสม่ำเสมอ
* [ ] ไม่มี allocation/boxing/fallback ที่ไม่จำเป็นใน hot path
* [ ] โค้ดอ่านง่าย และสอดคล้องกับสไตล์ทีม

---

## Troubleshooting

* **Ghost Text ไม่ขึ้น**: ตรวจสอบว่าเปิดไฟล์ที่เกี่ยวข้องจริง, Copilot เปิดใช้งาน, อินเทอร์เน็ตพร้อม
* **Suggestion ไม่ตรงใจ**: เพิ่มรายละเอียดคอมเมนต์, แยกงานย่อย (Layered Prompts), ใช้ Inline Chat อธิบายบริบทเพิ่ม
* **มีหลายคำตอบดี ๆ**: ใช้ Multi‑Suggestion Pane เปรียบเทียบ และเก็บ snippet ที่ดีที่สุดไว้ใช้ซ้ำ

---

## สิ้นสุด Lab

คุณได้ฝึกใช้ Copilot ครบมิติ: *Inline/Block*, *Command Palette*, *Inline Chat*, *Comments‑to‑Code (PE)* และ *Multi‑Suggestion Pane* เพื่อสร้าง `ProductService` ที่มีคุณภาพและพร้อมต่อยอดไปสู่การทดสอบและการเชื่อมต่อดาต้าเลเยอร์จริง
