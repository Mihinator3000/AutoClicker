# AutoClicker

На данный момент проект - простенький автокликер с небольшим функционалом. 

## Stack

- .NET 5
- WPF

## Функционал

Настриваемые координаты кликов, продолжительность, количество кликов в секунду.

## Планы

Планируется:
- Разбить автокликер на 2: Lite и Full
- Добавить настройки горячих клавиш. 

### Lite Version:

Добавить возможности:
- Выбора между Right/Mid/Left кликами.
- Задачи начальной задержки.
- Установки random delay между кликами.

### Full Version:

- Добавить все функции из Lite.
- Создать язык, с помощью которого пользователь сможет задавать клики, например:
  SetMouse(100, 100);
  Click(Right);
  Key(w);
  Sleep(100);
  Keys(Some words);
Добавить возможности:
- Имитирования нажатия с клавиатуры.
- Сохранять алгоритм в файлы, а также загружать его их них.
- Записывать активности пользователя с последующим преобразованием в вышеупомянутый язык и возможностью воспроизведения.


