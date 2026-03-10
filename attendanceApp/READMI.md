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

> **[SCREENSHOT: PROJEKTPLAN / MIRO ÜBERSICHT HIER EINFÜGEN]**
> *Beschreibung: Erste Skizze der Anforderungen und der geplanten Features.*

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

> **[SCREENSHOT: FLOWCHART / NASSI-SCHNEIDERMAN DIAGRAMM HIER EINFÜGEN]**
> *Beschreibung: Darstellung des Programmflusses von der Authentifizierung bis zur Hauptmenü-Steuerung.*

---

## 5. Implementierung & Umsetzung
Hier wird die schrittweise Umsetzung der technischen Kernkomponenten erläutert.

### Navigationskonzept (`Navigate.cs`)
Statt die Klassen direkt untereinander aufzurufen, wird ein **State-Management** genutzt. Über das Enum `AppStep` wird zentral gesteuert, welche Ansicht geladen wird. Dies verhindert einen StackOverflow.

> **[SCREENSHOT: CODE-SNIPPET NAVIGATE-LOGIK HIER EINFÜGEN]**
> *Erläuterung: Der Switch-Case-Block, der die verschiedenen App-States (Login, Menu, AddDate) steuert.*

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

> **[SCREENSHOT: DEBUGGING / BREAKPOINT BEI DATUMSPRÜFUNG HIER EINFÜGEN]**
> *Beschreibung: Hier sieht man die Fehlerbehandlung im Debugger, wenn ein falsches Format eingegeben wird.*

### Problem: Mehrfacheinträge
Ein Nutzer konnte denselben Tag mehrfach als anwesend markieren.
**Lösung:** Vor dem Hinzufügen zu `visitDates` wird mittels `.Contains(date)` geprüft, ob der Eintrag bereits existiert.

---

## 8. Quellenangaben
*   **Microsoft Dokumentation:** C# Enums, Dictionary Klassen, DateTime Parsing.
*   **StackOverflow:** Techniken für "Console Menu with Arrow Keys".
*   **KI-Unterstützung:** **Gemini (Google)** zur Strukturierung der Dokumentationsvorlage und Hilfestellung bei der C#-Syntax.
