# Инструкция по использованию приложения

### 1. Запустите приложение, запустив файл "TaskWinForms.exe" по пути TaskWinForms\bin\Debug\net8.0-windows.

### 2. В главном окне нажмите кнопку "Загрузить данные" и выберите CSV-файл с заказами "order.csv".
   ### Формат файла должен соответствовать следующим требованиям:
   #### - Поля разделены запятыми.
   #### - Поля в строке: Номер заказа, Вес, Район, Время доставки.
   #### - Пример строки:
   ####  Заказ16,5.5,Центральный,2023-05-01 10:30:00

### 3. После загрузки данных список заказов отобразится в таблице.

### 4. Выберите район доставки из выпадающего списка.

### 5. Установите время первой доставки, используя элемент управления даты и времени по центру приложения.

### 6. Нажмите кнопку "Фильтровать" для отображения заказов, соответствующих критериям.
   ###  Заказы в выбранном районе (если не выбран отоброзяться все районы).
   ###  Время доставки в интервале от времени первой доставки до +30 минут.

### 7. Результаты фильтрации отобразятся в таблице.

### 8. Чтобы сохранить результаты в CSV-файл, нажмите кнопку "Сохранить результаты" и выберите место для сохранения файла.

### 9. Все основные операции и ошибки записываются в файл логов "deliveryLog.xlsx" в папке с приложением.
