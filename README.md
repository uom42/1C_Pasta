# 1C Pasta

Прогамма имитирует ввод с клавиатуры табличной части документа 1С. Это может быть полезно, если ваша версия 1С ещё не имеет стороннего расширения, или вы не имеете возможности уставки таких расширений в вашу 1С, например если она в облаке и т.д.

# Прочитать
Читаем из буфера обмена табличные данные и отображаем их в виде таблицы.

* Формат данных в буфере обмена должен быть "как в Excel", т.е. строки разделяются переносом строки, столбцы разделяются табуляцией.

* Если данные из буфера успешно прочитаны, то становится доступна их вставка в 1С.

* Строку(и) в таблице можно удалять клавишей ***DEL***.


# Вставить в 1С
После нажатия этой кнопки, ищем среди запущенных процессов 1С, активируем его окно на передний план и вставляем в него данные.

**ВАЖНО!!! Заранее, в 1С в активном табличном документе, фокус ввода должен быть установлен на табличную часть документа!** Мы не переключаем фокус ввода между заголовочными полями документа и его табличной частью, т.к. у нас нет обратной связи от окна 1С и мы не знаем фактически что там происходит!


## Как вставляются данные:
1. Для добавления новой строки имитируется нажатие ***INS***.

3. Для ввода ячейки имитируется ввод с клавиатуры, потом "нажимается" ***TAB*** для переключения на следующую ячейку.

    Если отмечена опция "***Первая колонка это справочник***", считается что в первой колонке значение выбирается из справочника, ане просто текст/число.
    **ВАЖНО!!! В справочнике уже должен существовать такой вставляемый элемент, мы не создаём новые элементы справочника!**
    После набора текста ячейки, вместо ***TAB*** нажимается ***ENTER*** для подтверждения выбора элемента из справочника.

7. После ввода всех ячеек строки, имитируется нажатие ***F3***.


### Некоторые особенности и ограничения:
* Это подходит только для "простых" однострочных строк в таблице.

* Только одна (первая) ячейка строки может быть элементом справочника.

    Например, таким образом, можно заполнять документ "Требование на склад" для списания материалов по итогам месяца, где первая ячейка - выбор номенклатуры, а следующие - ввод количества и т.д.

* Между операциями ввода данных, делаются небольшие паузы, для ожидания обработки ввода со стороны 1С.

Это всё не всегда корректно работает и довольно часто бывают глюки.
В этом случае, просто щёлкните мышкой окно любой другой программы или рабочий стол, для смены фокуса.

* При потере фокуса окна 1С, ввод данных останавливается.