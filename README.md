# Unity Dialogue System

A clean, modular, and event-driven Dialogue System for Unity. Built using **ScriptableObjects** to store conversations and a lightweight Queue-based manager to handle the flow, making it incredibly easy to integrate into RPGs, visual novels, or any project requiring text interactions.

---

## ✨ Features

* **ScriptableObject Blueprints:** Write your dialogues, assign speaker names, and set character portraits entirely in the Unity Editor without touching code.
* **Queue-Based Flow:** Efficiently queues up conversation lines and feeds them to your UI one by one.
* **Event-Driven UI:** Uses C# Actions ("Action<DialogueLine>") to broadcast text updates, ensuring your game logic and canvas UI remain completely decoupled.
* **Plug & Play:** Easy to attach to NPCs, signs, or cutscene managers.

---

## 🧠 Design Notes

This system separates the **Dialogue Data** from the **Dialogue UI**. 
The "DialogueData" ScriptableObject simply holds the text, name, and images. The "DialogueManager" processes this data and shouts out to the rest of the game, "Here is the next line!" 

By relying on standard C# events, your UI scripts just need to listen for "OnLineStarted" to update the text boxes on screen. This prevents hard-coded references and makes the system memory-efficient and highly scalable.

---

## 📂 Included Scripts

* "DialogueLine.cs" - A serializable class defining a single line of spoken text, the speaker's name, and their portrait.
* "DialogueData.cs" - The ScriptableObject blueprint that holds a list of "DialogueLine"s.
* "DialogueManager.cs" - The brain of the system. It handles starting, advancing, and ending the conversation.
* "DialogueTrigger.cs" - A helper component to attach to NPCs or objects in your scene to easily start a specific dialogue.

---

## 🧩 How To Use

1. **Create a Dialogue:** Right-click in your Project window: "Create > Dialogue System > Dialogue". Add your lines of text, speaker names, and optional portrait sprites.
2. **Setup the Manager:** Attach the "DialogueManager.cs" script to a persistent GameObject in your scene (like your GameManager).
3. **Setup a Trigger:** Attach "DialogueTrigger.cs" to an NPC. Assign your new Dialogue Data asset and link the Manager.
4. **Triggering the Conversation:** Call this method from your player interaction script or an UnityEvent:

myDialogueTrigger.TriggerDialogue();

5. **Advancing the Text:** To go to the next line (e.g., when the player clicks a 'Next' button), call:

dialogueManager.DisplayNextLine();

6. **Listening for UI:** Subscribe your custom UI script to the static events to update your canvas:

DialogueManager.OnLineStarted += UpdateMyTextUI;
DialogueManager.OnDialogueEnded += HideMyTextUI;


---

## 🚀 Possible Extensions

* **Typewriter Effect:** Add a coroutine in your UI script that reveals the "DialogueLine.text" one character at a time.
* **Branching Paths:** Update "DialogueLine" to include an array of 'Choices', which link to different "DialogueData" objects based on player input.
* **Audio Voiceover:** Add an "AudioClip" variable to "DialogueLine.cs" and have the manager play it via an "AudioSource" when "DisplayNextLine()" is called.
* **Localization:** Swap the plain string text fields for string tables if you plan to support multiple languages.

---

## 🛠 Unity Version

Tested in Unity6+ (should also work without problems in the newer versions)

---

## 📜 License

MIT
