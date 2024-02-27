# Система диалогов для Unity

Этот проект представляет собой гибкую и масштабируемую систему диалогов для игр на Unity. Система позволяет легко создавать и управлять диалогами и ветвлениями диалогов через JSON файлы и интегрировать их с игровым процессом.

## Особенности

- **Легкость Редактирования**: Диалоги хранятся в JSON формате для удобства редактирования и быстрой интеграции.
- **Масштабируемость**: Поддерживает создание сложных диалогов с множественными ветвлениями и условиями.
- **Универсальность**: Может быть легко интегрирована в любой проект Unity без необходимости модификации существующего кода игры.
- **Поддержка Мультиязычности**: Легко добавляйте поддержку нескольких языков для ваших диалогов.

## Как начать

### Установка

1. Склонируйте репозиторий в ваш проект Unity или загрузите архив и распакуйте его в папку `Assets` вашего проекта.
2. Убедитесь, что в вашем проекте есть папка `Resources`, и переместите туда файлы диалогов JSON.

### Создание диалогов

Диалоги определяются в JSON файлах в папке `Resources`. Пример структуры файла:

```json
{
  "dialogues": [
    {
      "id": "dialogue1",
      "characterName": "NPC Name",
      "lines": [
        {
          "text": "Привет, путник!",
          "options": [
            {
              "text": "Ответить приветствием.",
              "leadsToDialogueId": "dialogue2"
            },
            {
              "text": "Пройти мимо.",
              "leadsToDialogueId": ""
            }
          ]
        }
      ]
    }
  ]
}
```

### Использование в игре

Для запуска диалога используйте:

```csharp
FindObjectOfType<DialogueManager>().StartDialogue("dialogue1");
```

## Разработка

### Стуктура проекта

`Scripts`: Содержит все необходимые скрипты для работы системы диалогов.

`Resources`: Папка для хранения файлов диалогов в формате JSON.