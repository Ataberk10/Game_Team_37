# 🎮 GameVsComputer – AI Number Game with Minimax & Alpha-Beta

This is a 2-player number game developed as a university project using C# and Windows Forms. It allows a human player to play against the computer using either the **Minimax** or **Alpha-Beta pruning** algorithm.

---

## 🧠 Game Rules

- The game starts with a number between **8 and 18** (inclusive).
- At each turn, the current number is multiplied by **2, 3, or 4**.
- If the result is **even**, the active player loses **1 point**.
- If the result is **odd**, the active player gains **1 point**.
- If the result ends in **0 or 5**, **1 point is added to the bank**.
- The game ends when the number reaches or exceeds **1200**.
- The player who makes the final move gets the bank points added to their score.

---

## 🕹️ Features

- Turn-based gameplay between **Human** and **Computer**
- Option to choose:
  - Who starts the game: Player / Computer
  - Which algorithm the computer uses: **Minimax** / **Alpha-Beta**
- Dynamic GUI with buttons, labels, and combo boxes
- Real-time score tracking
- Winner is declared at the end of the game
- Clean game logic and reusable data structure (`GameState`) for storing game nodes

---

## 📂 Project Structure

```
GameVsComputer/
│
├── Form1.cs               # Game logic and event handling
├── Form1.Designer.cs      # GUI design
├── GameState.cs           # Game tree node structure
├── Program.cs             # Entry point
├── GameVsComputer.csproj  # Project file
└── README.md              # This file
```

---

## ▶️ How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/GameVsComputer.git
   ```
2. Open `GameVsComputer.sln` with **Visual Studio**.
3. Set startup project if needed.
4. Press `F5` or click **Start** to run the game.

---

## 👨‍🏫 Notes for Evaluators

- ✅ `GameState` class is used to store game tree nodes (as required).
- ✅ Both **Minimax** and **Alpha-Beta pruning** algorithms are implemented.
- ✅ Human and computer turns are alternated with visual updates.
- ✅ Follows all project guidelines including GUI requirement.

---

## 📷 Screenshot

> *(Add a screenshot here if desired using `![screenshot](path)`)*

---

## 📜 License

This project is developed for educational purposes only.
