
# 🎶 **Melodify** – פלטפורמת המוזיקה המותאמת שלך

## 📝 **תקציר**
**Melodify**  הוא פרויקט ייחודי המאפשר למשתמשים להאזין למוזיקה, ליצור רשימות השמעה אישיות, לסמן מועדפים, וליצור חוויה מותאמת אישית. פרויקט זה, שמיושם בטכנולוגיות C#, Angular, ו-SQL, בנוי במודל 3 שכבות לשיפור היציבות, הסדר והתחזוקה.

---

## 🌟 **תכונות עיקריות**
- 🎧 **האזנה לשירים** – גישה למגוון רחב של שירים לפי קטגוריות, אמנים, ואלבומים.
- 📜 **יצירת רשימות השמעה** – אפשרות ליצור ולערוך פלייליסטים אישיים.
- 💖 **ניהול מועדפים** – סימון אמנים ושירים מועדפים לגישה מהירה.
- 📌 **תיעדוף שירים** – קביעת העדפות לפי סדר השירים הרצוי.
- 🎶 **האזנה לפלייליסטים קיימים** – גישה לרשימות השמעה מומלצות.
- 🧑 **אמנים** - צפייה ברשימת האמנים וקבלת מידע אודותם.

---

## 🛠 **טכנולוגיות בשימוש**
- **Backend**: C#  עם SQL, במודל 3 שכבות:
  - **Data Layer** – גישה ואינטראקציה עם בסיס הנתונים.
  - **Business Logic Layer** – יישום כללי לוגיקה עסקית ומידול.
  - **Presentation Layer** – ממשק API נגישות צד לקוח.
- **Frontend**: Angular (גרסה 17.3.7) – מבטיח חוויית משתמש חלקה ואינטואיטיבית.

---

## 🚀 **התקנה והרצה של הפרויקט**

### שלב 1: שיבוט הפרויקט
1. העתיקי את ה-URL של הריפוזיטורי הזה.
2. פתחי את סביבת העבודה שלך והורידי את הפרויקט בעזרת הפקודה:
   ```bash
   git clone https://github.com/miryamaximov/Melodify.git
   ```

### שלב 2: התקנת שכבת השרת (Backend)
1. ודאי שאת ב-Visual Studio ושה-C# שלך מעודכן.
2. התחברי לבסיס הנתונים שלך ב-SQL, והגדרי את נתוני החיבור ב-`appsettings.json`.
3. הריצי את הפרויקט על מנת להפעיל את שרת ה-API.

### שלב 3: התקנת שכבת הלקוח (Frontend)
1. בתיקיית Angular, ודאי שהתקנת את Node.js ו-NPM.
2. הריצי את הפקודות הבאות להתקנת כל התלויות ולהפעלת השרת:
   ```bash
   npm install
   ng serve
   ```

3. עכשיו ניתן לגשת לאפליקציה בדפדפן בכתובת [http://localhost:4200](http://localhost:4200).

---

## 📂 **מבנה התיקיות**

```plaintext
📦 Project Root
 ┣ 📂 Backend (C# 3-Tier Structure)
 ┣ 📂 Frontend (Angular)
 ┗ 📄 README.md
```

---

## 🤝 **הנחיות לתרומה**
כולנו מוזמנים לתרום! ניתן לשלוח Pull Requests עם תוספות ושיפורים לקוד ולדווח על תקלות בעזרת Issues.

---

## 📝 **רישיון**
פרויקט זה מפותח כקוד פתוח.
