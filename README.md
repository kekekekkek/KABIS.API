# КАБИС.API
### Введение
Данный модуль / библиотека (`.dll`) позволит Вам взаимодействовать с базой данных [КАБИС](https://kabis.kz/kabis.htm) напрямую, при помощи функций экспорта, без использования графической обёртки, на которую помимо этого наложено множество ограничений.
<br><br>
На официальном [сайте](https://kabis.kz/kabis2.htm) разработчика есть упоминание про `API`, но более подробную информацию по этому поводу, кроме пункта с описанием этой возможности, мне найти не удалось :(
<br><br>
Но, так как эта возможность даёт выполнять ряд определённых задач с базой данных библиотеки, Вы и можете наблюдать решение данной проблемы в виде модуля, где имеются все необходимые функции экспорта для манипуляции данными в базе данных.
<br><br>
База данных работает при помощи драйвера [ODBC](https://ru.wikipedia.org/wiki/ODBC), поэтому решение данной проблемы не заставило себя долго ждать. Так как я не смог открыть файл базы данных при помощи `MS Access` и других программ управления базами данных, этот драйвер оставался единственной надеждой.
<br><br>
В будущем планируется доработка модуля и последующее добавление новых функций для более гибкого взаимодействия с базой данных библиотеки. Также, ниже представленные возможности я скоро сделаю бесплатными, а точнее расскажу, как это можно сделать без траты своих средств бесплатно (`ничего не буду обещать`).<br><br>
![Screenshot_1](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_1.png)<br><br>
Посмотреть более подробную документацию можно по этой [ссылке](https://kekekekkek.github.io/KABIS.API/) (**v0.1**).<br>
Описать проблемы с работой библиотек можно [здесь](https://github.com/kekekekkek/KABIS.API/issues).<br>
Или можете задать мне свой вопрос в [Discord](https://discordapp.com/users/428279123526549506).
<br><br>
**P.S**: Модуль *`kapi32u (utils).dll`* необходим для выполнения специфических задач, таких как `получение пароля от БД из памяти программы`. Возможно это можно сделать каким-то иным путём, но пока я нашёл только это решение данной проблемы.
# Начало работы
### Клонирование
Перед началом работы, склонируйте данный репозиторий в удобное для Вас место:
```
git clone https://github.com/kekekekkek/KABIS.API
```
Скачать репозиторий можно по этой [ссылке](https://github.com/kekekekkek/KABIS.API/archive/refs/heads/main.zip).<br>
Скачать последнюю версию библиотек можно по этой [ссылке](https://github.com/kekekekkek/KABIS.API/releases/download/v0.1/Modules.rar).<br><br>
После того, как все библиотеки и файлы были размещены на Вашем компьютере, Вам необходимо приступить к созданию проекта.
<br>
### Visual Studio
В данном примере будет продемонстрировано то, как правильно нужно настраивать проект для корректной работы библиотек. В данном случае проект будет построен на использовании технологии `.NET` (работу функций экспорта на других языках я не тестировал).
1. Запустите `Visual Studio` и в появившемся окне выберите пункт `Создание проекта`;<br><br>
![Screenshot_2](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_2.png)<br><br>
2. Далее, в качестве шаблона проекта Вы можете выбрать `Консольное приложение (.NET Framework)` и нажать на кнопку `Далее`;<br><br>
![Screenshot_3](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_3.png)<br><br>
3. В следующем окне Вам необходимо будет дать имя проекту и выбрать платформу `.NET`, после чего, нажать на кнопку `Создать`. Рекомендуется выбирать платформу не ниже версии `4.7`;<br><br>
![Screenshot_4](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_4.png)<br><br>
4. В окне редактора кода, прежде чем начинать работу с библиотеками, первое что Вам потребуется сделать - это настроить проект. В `обозревателе решений` Вам необходимо будет нажать `правой кнопкой мыши` по названию проекта и в контекстном меню выбрать пункт `Свойства`;<br><br>
![Screenshot_5](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_5.png)<br><br>
5. В окне настроек необходимо будет выбрать вкладку `Сборка` и внутри неё указать `целевую платформу` и в качестве значения выбрать `x86`, так как драйвер базы данных и сами библиотеки являются `32-х` разрядными. Также, Вы можете оставить все настройки по умолчанию, с включённой галочкой `Предпочтительна 32-разрядная версия`;<br><br>
![Screenshot_6](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_6.png)<br><br>
6. Далее, в редакторе кода Вам нужно будет скомпилировать проект, нажав на кнопку `▶ Пуск` (**запуск с отладкой**) или кнопку `▷` (**запуск без отладки**) вверху программы, чтобы `IDE` создала файлы сборки в корневном каталоге исходного кода программы (также Вы можете воспользоваться горячими клавишами: `Ctrl + B`, `Shift + F5` (**запуск без отладки**) или `F5` (**запуск с отладкой**));<br><br>
![Screenshot_7](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_7.png)<br><br>
7. Теперь откройте каталог, в котором находится исполняемый файл скомпилированной программы. Если Вы компилировали в конфигурации `Release` то путь будет `..\bin\Release`, если в `Debug` то `..\bin\Debug`;
8. После открытия каталога, переместите библиотеки `kapi32.dll` и `kapi32u.dll` из скачанного репозитория (из папки `Modules`) в эту директорию, чтобы исполняемый файл и библиотеки находились в одной папке;<br><br>
![Screenshot_8](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_8.png)<br><br>
9. После этого можно сказать, что Ваш проект полностью настроен и готов к работе с библиотеками `kapi32.dll` и `kapi32u.dll`.<br>
### Важно
В случае проблем с отладкой приложения, попробуйте запустить его непосредственно из папки, в которой располагается исполняемый файл программы. Это должно решить проблему.<br>
# Функции экспорта библиотек
Согласование о вызовах нужно указывать именно так, как прописано в примерах импорта функций.
### [+] kapi32.dll
- `PtrToStr` - Преобразовывает указатель на массив из символов в текст;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string PtrToStr(IntPtr intPtr);
```
<br>

- `OpenDataBase` - Открывает локальную базу данных для последующего выполнения к ней запросов;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static bool OpenDataBase(string strDataBase, string strPassword);
```
<br>

- `EnumTables` - Позволяет перечислить все имеющиеся таблицы в базе данных. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string EnumTables();
```
<br>

- `GetTableCount` - Получает текущее количество таблиц в базе данных. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static int GetTableCount();
```
<br>

- `EnumFields` - Позволяет перечислить и получить имена всех полей, которые находятся в таблице, указанной в аргументе функции. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string EnumFields(string strTable);
```
<br>

- `GetFieldCount` - Позволяет получить количество полей в таблице, указанной в аргументе функции. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static int GetFieldCount(string strTable);
```
<br>

- `SelectAllFrom` - Извлекает все данные таблицы вместе с полями через запрос *"SELECT * FROM `TableName`;*". Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string SelectAllFrom(string strTable, bool bOutput);
```
<br>

- `CreateCustomQuery` - Позволяет выполнять кастомные запросы к базе данных. Для примера *"SELECT `id`, `Password`, `UserPC` FROM `Librarians`;"*. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string CreateCustomQuery(string strQuery);
```
<br>

- `UnloadTable` - Позволяет выгрузить все записи таблицы вместе с полями в какой-либо файл с определёнными разделителями. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static string UnloadTable(string strTable, string strFile, int iType, bool bOutput);
```
<br>

- `GetTableRecords` - Получает количество записей в таблице, указанной в аргументе функции. Всегда должна выполняться после вызова **OpenDataBase**;<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static int GetTableRecords(string strTable);
```
<br>

- `CloseDataBase` - Закрывает соединение с базой данных. Должна вызываться после завершения работы с базой данных.<br>
Пример импорта:
```C#
[DllImport("kapi32.dll", CallingConvention = CallingConvention.StdCall)]
extern public static bool CloseDataBase();
```
### [+] kapi32u.dll
Модуль (библиотека) содержит в себе всего лишь одну экспортируемую функцию. Которая выполняет своё главное действие только один раз.
- `ScanForPass` - Извлекает из памяти процесса (**программы**) пароль для базы данных.<br>
Пример импорта:
```C#
[DllImport("kapi32u.dll", CallingConvention = CallingConvention.StdCall)]
extern public static IntPtr ScanForPass(string strAppName);
```
### Документация
Более детальную информацию с примерами кода и работы с функциями экспорта Вы сможете найти в документации к библиотекам.
1. Ссылка на документацию: https://kekekekkek.github.io/KABIS.API/;
2. Также, в репозитории хранятся исходные коды программ (в папке `Examples`), которые можно применять на практике для интеграции библиотечной системы с другими корпоративными системами.

# Взаимосвязь таблиц
Обычно, при выгрузке таблицы с использование функции `UnloadTable`, выгружаются только те поля, которые содержатся в той таблице, которую Вы указали в аргументе функции. Например таблица 
`Books` содержит в себе только такие поля: `ID_Book`, `Desc_1`, `Desc_21`, `Desc_29`, `Desc_31`, `ID_Catalog`, `ID_Label`, `N_Label`, `ID_Librarian`, `FirstDate`, `LastDate`, `Desc_65`, 
`Bk_GUID`, `Deleting`, `SortStr`, `RecDate`, `CopyCnt`, `Desc_77`, `ID_Librarian2`, но не содержит дополнительных полей, таких как `Desc_25` или `Desc_32`, которые содержат дополнительную 
информацию к описанию книжной записи.<br><br>
Для решения данной проблемы, Вы можете установить взаимосвязь между таблицами, используя ключевое слово `JOIN` при выполнении *SQL-запроса*.<br><br>
Для выполнения кастомных запросов к базе данных можно использовать вызов функции [`CreateCustomQuery`](https://kekekekkek.github.io/KABIS.API/#CreateCustomQuery) с переданным в неё кастомным запросом.<br><br>
Наглядную взаимосвязь таблиц можно увидеть на скриншотах ниже:<br><br>
![Screenshot_9](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_9.png)<br><br>
![Screenshot_10](https://github.com/kekekekkek/KABIS.API/blob/main/Images/Screenshot_10.png)

# Заключение
Вы можете использовать все функции экспорта так, как захотите, всё зависит только от Вашего воображения. Теперь, при помощи данного инструмента у Вас появится возможность интеграции библиотечной системы KABIS с другими корпоративными системами, по крайней мере у меня.<br><br>
Также, в случае обнаружения проблем библиотеки или проблем при работе с ней, Вы можете задать мне любые вопросы по этому поводу в [Discord](https://discordapp.com/users/428279123526549506).
