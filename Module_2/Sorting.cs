using System;

namespace Module_2
{
    public class Sorting
    {
		/// <summary>
		/// Отсортировать массив таким образом, чтоб не было повторяющихся слов
		/// </summary>
		/// <param name="collectionWords">Зубчатый массив, содержащий в каждом массиве символы</param>
		public char[][] SortingCollectionWords(char[][] collectionWords)
		{
			// Размер первого массива
			int sizeFirstArray = 0;
			// Размер второго массива
			int sizeSecondArray = 1;
			// Перменная для смещения по массиву
			int countArray = 1;
			// Перменная для переставления букв
			bool flagCoincidence = true;

			// В этом цикле запоминаем размер первого массива и сравниваем его с другими
			for (int r = 0; r < collectionWords.Length; r++)
			{
				sizeFirstArray = collectionWords[r].Length;

				// В этом цикле мы смещаемся для сравнения двух соседних массивов
				for (int i = countArray; i < collectionWords.Length; i++)
				{
					// Запоминаем длину следующего массива
					sizeSecondArray = collectionWords[i].Length;
					flagCoincidence = true;

					// Если размер совпадает
					if (sizeFirstArray == sizeSecondArray)
					{

						// Начинаем проверять эти массивы по буквенно
						for (int j = 0; j < collectionWords[i].Length; j++)
						{
							if (collectionWords[r][j] == collectionWords[i][j])
							{
								continue;
							}
							else
							{
								flagCoincidence = false;
								break;
							}
						}

						// Двигаем символы
						if (flagCoincidence)
						{
							// Индекс последнего элемента
							int lastChar = collectionWords[r].Length - 1;
							// В переменную записываем значение из нулевой позиции
							char tempChar = collectionWords[i][0];

							for (int e = 0, q = 1; e < collectionWords[i].Length - 1; e++, q++)
							{
								collectionWords[i][e] = collectionWords[i][q];
							}
							collectionWords[i][lastChar] = tempChar;
							r = -1;
							countArray = 0;
							break;
						}
					}

				}
				countArray++;
			}
			return collectionWords;
		}
	}
}
