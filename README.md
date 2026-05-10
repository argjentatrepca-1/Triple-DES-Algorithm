# 🔐 Aplikacion për Enkriptim dhe Dekriptim (3DES-2Key)

Ky projekt është një implementim në gjuhën **C#** i algoritmit simetrik **3DES (Triple DES)** duke përdorur metodën **2-Key**. Aplikacioni ofron një ndërfaqe përmes konsolës (Console Application) për të siguruar fajllat përmes enkriptimit dhe rikthimin e tyre përmes dekriptimit.

---

## 👥 Anëtarët e Grupit dhe Kontributi

Projekti është realizuar në mënyrë modulare, ku secili anëtar ka mbuluar një pjesë specifike të arkitekturës:

*   **Jona Elezi** – `CryptoEngine.cs`: Implementimi i logjikës së enkriptimit/dekriptimit.
*   **Ardita Imeri** – `FileHandler.cs`: Menaxhimi i leximit dhe shkrimit të fajllave në disk.
*   **Argjenta Trepça** – `Program.cs`: Zhvillimi i ndërfaqes me përdoruesin dhe kontrolli i rrjedhës.
*   **Arbëron Hasanaj** – `SecurityTests.cs`: Zhvillimi i testeve për validimin e sigurisë.

---

## 🎯 Qëllimi i Projektit

*   **Implementimi i 3DES-2Key:** Përdorimi i strukturës K1-K2-K1 për enkriptim.
*   **Përdorimi i CBC Mode:** Sigurimi që blloqet e të dhënave janë të lidhura në zinxhir për siguri më të lartë.
*   **Menaxhimi i Fajllave:** Manipulimi i stream-eve të të dhënave pa korruptuar fajllin origjinal.

---

## 🛠 Detajet Teknike

### Algoritmi dhe Konfigurimi
| Karakteristika | Specifikimi |
| :--- | :--- |
| **Algoritmi** | Triple DES (3DES) |
| **Struktura e Çelësit** | 2-Key (16 bytes / 128 bits) |
| **Mode** | CBC (Cipher Block Chaining) |
| **Padding** | PKCS7 |
| **IV (Init Vector)** | 8 bytes (Static: `87654321`) |

### Struktura e Projektit
```plaintext
Triple_DES_Algorithm/
├── Program.cs           # Pika hyrëse dhe UI e konsolës
├── CryptoEngine.cs      # Motori kriptografik (3DES Logic)
├── FileHandler.cs       # Klasa ndihmëse për operacionet me fajlla
├── src.csproj           # Fajlli i konfigurimit të projektit
└── tests/
    └── SecurityTests.cs # Testet e validimit