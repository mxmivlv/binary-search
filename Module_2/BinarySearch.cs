using System.Collections.Generic;

namespace Module_2
{
    public class BinarySearch
    {
		/// <summary>
		/// Поиск в массиве
		/// </summary>
		/// <param name="collectionLanguages">Массив</param>
		/// <param name="language">Искомое слово</param>
		/// <returns>Истина если искомый объект найден, ложь в противном случае</returns>
		public bool SearchInTheCollectionLanguage(string[] collectionLanguages, string language)
		{
			// Левая граница массива
			int leftBorder = 0;
			// Правая граница массива
			int rightBorder = collectionLanguages.Length;
			// Уентральная позиция массива
			int midle = 0;
			// Возвращаемое значение
			bool flagReturn = false;

			while (leftBorder < rightBorder)
			{
				// Вычисляем среднее значение массива
				midle = (leftBorder + rightBorder) / 2;
				// Вычисляем, какое слово "больше"
				var result = string.Compare(collectionLanguages[midle], language);
				// Если искомое значение выше languagesList[midle]
				if (result < 0)
				{
					leftBorder = midle+1;
				}
				// Если искомое значение ниже languagesList[midle]
				if (result > 0)
				{
					rightBorder = midle;
				}
				if (result == 0)
				{
					return true;
				}
			}
			return flagReturn;
		}

		/// <summary>
		/// Поиск в массиве, в заданном диапазоне
		/// </summary>
		/// <param name="collectionUsers">Массив сортированный по Iq</param>
		/// <param name="lowerIqBound">Нижняя граница</param>
		/// <param name="upperIqBound">Верхняя граница</param>
		/// <returns>Коллекцию имен</returns>
		public List<string> FindUsers(DatingUser[] collectionUsers, int lowerIqBound, int upperIqBound)
		{
			DatingUser datingUser = new DatingUser();
			// Левая граница
			int leftBorder = 0;
			// Средняя граница
			int midle = 0;
			// Правая граница
			int rightBorder = collectionUsers.Length;
			// Коллекция для вывода результата
			List<string> result = new List<string>();

			// Условие выхода из цикла
			while (leftBorder < rightBorder)
			{
				midle = (leftBorder + rightBorder) / 2;
				// Если нижняя граница больше, чем центральная
				if (collectionUsers[midle].Iq < lowerIqBound)
				{
					leftBorder = midle + 1;
				}
				else
				{
					rightBorder = midle;
				}
			}
			for (int i = rightBorder; i < collectionUsers.Length; i++)
			{
				if (collectionUsers[i].Iq > upperIqBound)
					break;
				result.Add(collectionUsers[i].Name);
			}
			return result;
		}

		/// <summary>
		/// Нахождение переменной в массиве, который может быть отсортирован в двух направлениях
		/// </summary>
		/// <param name="collectionPhoneNumbers">Массив для поиска</param>
		/// <param name="phoneNumber">Искомое значение</param>
		/// <returns>Индекс если нашел, если нет -1</returns>
		public int FindPhoneNumber(long[] collectionPhoneNumbers, long phoneNumber)
		{
			// Левая граница массива
			int leftBorder = 0;
			// Правая граница массива
			int rightBorder = collectionPhoneNumbers.Length;
			// Уентральная позиция массива
			int midle = 0;
			// Если массив сортирован от большего к меньшему
			bool flagSortedMaxMin = false;

			if (collectionPhoneNumbers[leftBorder] > collectionPhoneNumbers[rightBorder-1])
			{
				flagSortedMaxMin = true;
			}

			while (leftBorder <= rightBorder)
			{
				// Вычисляем среднее значение массива
				midle = (leftBorder + rightBorder) / 2;

				if (flagSortedMaxMin)
				{
					if (collectionPhoneNumbers[midle] < phoneNumber)
					{
						rightBorder = midle-1;
					}

					if (collectionPhoneNumbers[midle] > phoneNumber)
					{
						leftBorder = midle+1;
					}
					if (collectionPhoneNumbers[midle] == phoneNumber)
						return midle;
				}
				else
				{
					if (collectionPhoneNumbers[midle] > phoneNumber)
					{
						rightBorder = midle-1;
					}

					if (collectionPhoneNumbers[midle] < phoneNumber)
					{
						leftBorder = midle+1;
					}
					if (collectionPhoneNumbers[midle] == phoneNumber)
						return midle;
				}
			}
			return -1;
		}

		/// <summary>
		/// Вставка новых слов в словарь
		/// </summary>
		/// <param name="collectionWord">Коллекция слов</param>
		/// <param name="word">Слово для вставки</param>
		/// <returns>Коллекция с добавленным элементом. Если такой элемент есть в коллекции, добавление не происходит</returns>
		public List<string> InsertNewWord(List<string> collectionWord, string word)
		{
			// Левая граница массива
			int leftBorder = 0;
			// Правая граница массива
			int rightBorder = collectionWord.Count;
			// Центральная позиция массива
			int midle = 0;
			// Переменная для добавления элемента
			bool flagAddElement = true;

			while (leftBorder < rightBorder)
			{
				// Вычисляем среднее значение массива
				midle = (leftBorder + rightBorder) / 2;
				// Вычисляем, какое слово "больше"
				var result = string.Compare(collectionWord[midle], word);

				// Если искомое значение выше newRussianDictionary[midle]
				if (result < 0)
				{
					leftBorder = midle + 1;
				}
				// Если искомое значение ниже newRussianDictionary[midle]
				if (result > 0)
				{
					rightBorder = midle;
				}
				if (result == 0)
				{
					flagAddElement = false;
					break;
				}
			}

			// Получаем текущий размер массива
			rightBorder = collectionWord.Count;
			// Если левая граница равна правой границе, значит добавление должно быть в конце
			if (leftBorder == rightBorder)
			{
				collectionWord.Add(word);
				flagAddElement = false;
			}

			// Условие для добавления клиента, если такого клиента нет в коллекции или добавление должно быть в середине массива
			if (flagAddElement)
			{
				// Заранее увеличиваем массив
				collectionWord.Add("0");
				for (int i = rightBorder, r = i - 1; i > leftBorder; i--, r--)
				{
					// В последний записываем предпоследнее значение
					collectionWord[i] = collectionWord[r];
				}
				// В индекс места вставки вставляем нашу слово
				collectionWord[leftBorder] = word;
			}
			return collectionWord;
		}

        /// <summary>
        /// Поиск в коллекции экземпляра с заданным рейтингом, игрок с таким рейтингом гарантированно есть в коллекции
        /// </summary>
        /// <param name="collectionPlayers">Коллекция игроков</param>
        /// <param name="ratingPlayer">Рейтинг для поиска</param>
        /// <returns>Индекс игрока. Если таких игроков несколько, возвращает индекс последнего</returns>
        public int SearchPlayer(List<Player> collectionPlayers, int ratingPlayer)
        {
            // Левая граница массива
            int leftBorder = 0;
            // Правая граница массива
            int rightBorder = collectionPlayers.Count-1;
            // Центральная позиция массива
            int midle = 0;

            while ((leftBorder+1) < rightBorder)
            {
                // Вычисляем среднее значение массива
                midle = (leftBorder + rightBorder) / 2;

                // Если искомое значение выше queue[midle]
                if (ratingPlayer >= collectionPlayers[midle].Rating)
                {
                    leftBorder = midle;
                }
                // Если искомое значение ниже queue[midle]
                if (ratingPlayer < collectionPlayers[midle].Rating)
                {
                    rightBorder = midle-1;
                }
            }
            return rightBorder;
        }

		/// <summary>
		/// Добавление клиента в заданный индекс
		/// </summary>
		/// <param name="collectionPlayer">Коллекция игроков</param>
		/// <param name="indexToInsert">Индекс для вставки</param>
		/// <param name="newPlayer">Экземпляр игрока</param>
		/// <returns>Коллекцию с вставленным новым игроком</returns>
		public List<Player> InsertPlayerInCollectionPlayer(List<Player> collectionPlayer, int indexToInsert, Player newPlayer)
		{
			// Получаем текущий размер массива
			int currentSizeList = collectionPlayer.Count;
			// Если индекс равен размеру коллекции, значит добавление должно быть в конце
			if (indexToInsert == currentSizeList)
			{
				collectionPlayer.Add(newPlayer);
			}

			// В противном случае
			else
			{
				// Заранее увеличиваем массив
				collectionPlayer.Add(new Player(0, "0"));
				for (int i = currentSizeList, r = i - 1; i > indexToInsert; i--, r--)
				{
					// В последний записываем предпоследнее значение
					collectionPlayer[i] = collectionPlayer[r];
				}
				// В индекс места вставки вставляем нашу слово
				collectionPlayer[indexToInsert] = newPlayer;
			}
			return collectionPlayer;
		}
	}
}
