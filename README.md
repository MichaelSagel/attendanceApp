# Dokumentation: Anwesenheits-Tracker "Präsenztage 25-4"

Diese Dokumentation bietet einen vollständigen Überblick über die Entstehung, Planung und technische Umsetzung der `attendanceApp`.

---

## 1. Gliederung
1. [Projektantrag & Planung](#2-projektantrag--planung)
2. [Zeitplanung](#3-zeitplanung)
3. [Systemarchitektur & Logik (Flowcharts)](#4-systemarchitektur--logik-flowcharts)
4. [Implementierung & Umsetzung](#5-implementierung--umsetzung)
5. [Lösungsansätze](#6-lösungsansätze)
6. [Schwierigkeiten & Debugging](#7-schwierigkeiten--debugging)
7. [Quellenangaben](#8-quellenangaben)

---

## 2. Projektantrag / Planung
**Zielsetzung:**  
Entwicklung einer C#-Konsolenanwendung zur effizienten Verwaltung von Präsenztagen. Nutzer sollen sich registrieren, einloggen und ihre Anwesenheit dokumentieren können. Die App berechnet automatisch die verbleibenden Tage bis zum Erreichen des Solls (134 Tage).

**Kernfunktionen:**
*   Benutzerverwaltung (Registrierung/Login).
*   Interaktive Menüführung über Pfeiltasten.
*   Validierung von Datumseingaben.
*   Statusübersicht der besuchten Tage.

**<img width="655" height="339" alt="image" src="https://github.com/user-attachments/assets/a51c5f37-1b54-4571-b125-49936ee907c1" />**

---

## 3. Zeitplanung
Das Projekt wurde in einem Zeitraum von 7 Tagen mit einem täglichen Arbeitspensum von ca. 8 Stunden umgesetzt.



| Tag | Phase | Tätigkeit | Dauer |
|:--- |:--- |:--- |:--- |
| **Tag 1** | **Analyse** | Anforderungsdefinition, Recherche zu C# Best Practices, Miro-Board. | 8h |
| **Tag 2** | **Design** | Festlegung der Klassenstruktur (`UserProfile`, `Navigate`), Enums. | 8h |
| **Tag 3** | **Setup** | Grundgerüst in Visual Studio, Implementierung der `Navigate`-Logik. | 8h |
| **Tag 4** | **Logik I** | Programmierung der Benutzerverwaltung (Registrierung, Login, Session). | 8h |
| **Tag 5** | **Logik II** | Implementierung der Datumsverarbeitung (`Date.cs`), Validierung. | 8h |
| **Tag 6** | **UI/UX** | Optimierung der Konsole, Pfeiltasten-Steuerung, visuelles Feedback. | 8h |
| **Tag 7** | **Abschluss** | Intensives Bugfixing (Debugging), Refactoring und Dokumentation. | 8h |

---

## 4. Systemarchitektur & Logik (Flowcharts)
Die gesamte Programmlogik wurde vorab visuell geplant, um zirkuläre Aufrufe zu vermeiden.

**Link zum Board:** [Projekt-Logik auf Miro ansehen](https://miro.com)
---

## 5. Implementierung & Umsetzung
Hier wird die schrittweise Umsetzung der technischen Kernkomponenten erläutert.

### Navigationskonzept (`Navigate.cs`)
Statt die Klassen direkt untereinander aufzurufen, wird ein **State-Management** genutzt. Über das Enum `AppStep` wird zentral gesteuert, welche Ansicht geladen wird. Dies verhindert einen StackOverflow.

**<img width="366" height="335" alt="image" src="https://github.com/user-attachments/assets/f998fb08-e876-4fa0-81a0-51f2452ae3b0" />**
**<img width="566" height="672" alt="image" src="https://github.com/user-attachments/assets/f33db61b-cb50-47e7-8277-8c11d4e9c007" />**
Der `switch-case`-Block in der Klasse `Navigate` steuert den zentralen Programmfluss:

* **Zweck:** Fungiert als **Dispatcher**, der den aktuellen Status (`AppStep`) auswertet.
* **Logik:** Je nach Zustand wird die passende Klasse aufgerufen und die entsprechende Methode (`SignIn`, `UserMenu`, etc.) ausgeführt.
* **Steuerung:** Ermöglicht den sauberen Wechsel zwischen Startseite, Login, Registrierung und Hauptmenü.


### Interaktive Konsole (`Welcome.cs` / `MainMenu.cs`)
Um die Benutzerfreundlichkeit zu erhöhen, wurde auf `Console.ReadLine` verzichtet. Stattdessen wird `Console.ReadKey(true)` verwendet, um Menüpunkte mit Pfeiltasten auszuwählen.

---

## 6. Lösungsansätze
*   **Globaler Status:** Die statische Klasse `Session` wurde gewählt, um den `CurrentUser` systemweit verfügbar zu machen.
*   **Dictionary statt Liste:** Für die `UserList` wurde ein `Dictionary<string, UserProfile>` verwendet. Dies ermöglicht einen schnellen Zugriff auf Benutzerdaten anhand der E-Mail (Key) in $O(1)$.

---

## 7. Schwierigkeiten & Debugging

### Problem: Formatierung der Datumseingabe
Bei der manuellen Eingabe kam es oft zu Abstürzen (`FormatException`).
**Lösung:** Einsatz von `DateTime.TryParseExact` mit dem festen Format `"dd.MM.yyyy"`. 

**<img width="1389" height="470" alt="image" src="https://github.com/user-attachments/assets/7b0074ff-aeae-4e82-92b4-e178acf4a2c7" />**
Die Methode `addAttendaceDay` übernimmt die Eingabe und Validierung von Datumsangaben:

* **Eingabe-Validierung:** Nutzt `DateTime.TryParseExact`, um sicherzustellen, dass das Datum exakt im Format `TT.MM.JJJJ` eingegeben wird.
* **Fehlerbehandlung:** Bei einem falschen Format wird eine Fehlermeldung ausgegeben und die Methode rekursiv erneut aufgerufen.
* **Verarbeitung:** Nur bei validem Datum wird die Logik zur Markierung der Anwesenheit in der Klasse `Date` angestoßen.

### Problem: Mehrfacheinträge
Ein Nutzer konnte denselben Tag mehrfach als anwesend markieren.
**Lösung:** Vor dem Hinzufügen zu `visitDates` wird mittels `.Contains(date)` geprüft, ob der Eintrag bereits existiert.

---

## 8. Quellenangaben
*   **Microsoft Dokumentation:** C# Enums, Dictionary Klassen, DateTime Parsing.
*   **StackOverflow:** Techniken für "Console Menu with Arrow Keys".
*   **KI-Unterstützung:** **Gemini (Google)** zur Strukturierung der Dokumentationsvorlage und Hilfestellung bei der C#-Syntax.
