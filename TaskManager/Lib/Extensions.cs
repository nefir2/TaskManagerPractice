namespace TaskManager.Lib
{
	public static class Extensions
	{
		/// <summary>
		/// метод вырезающий подстроку из общей строки по указанным позициям.
		/// </summary>
		/// <remarks>
		/// <paramref name="start"/>: знак под указанным номером возвращается в составе подстроки. <br/>
		/// <paramref name="end"/>: знак под указанным номером не возвращается в составе подстроки.
		/// </remarks>
		/// <param name="value">строка, из которой вырезается подстрока.</param>
		/// <param name="start">точка начала выреза.</param>
		/// <param name="end">точка окончания выреза.</param>
		/// <returns>вырезанная подстрока типа <see cref="string"/>.</returns>
		/// <exception cref="ArgumentException"/>
		/// <exception cref="IndexOutOfRangeException"/>
		public static string Cut(this string value, int start, int end)
		{
			if (start > end) throw new ArgumentException("the start of cutting string mustn't be greater than end."); //начальная позиция для вырезания подстроки не может быть больше конечной позиции.
			if (start < 0 || end < 0) throw new IndexOutOfRangeException("start or end of string can't be less than zero."); //начало или конец вырезания подстроки не может быть меньше нуля.
			if (start > value.Length || end > value.Length) throw new IndexOutOfRangeException("start or end of string can't be greater than end of string."); //начало или конец вырезания подстроки не может быть больше длины строки.

			string cutted = "";
			for (int i = start; i < end; i++) cutted += value[i];
			return cutted;
		}
		/// <summary>
		/// makes from array <see cref="char"/><c>[]</c> to <see cref="string"/> object.
		/// </summary>
		/// <remarks>
		/// if <paramref name="chars"/> is empty, then returns <c>""</c>.
		/// </remarks>
		/// <param name="chars">array of <see cref="char"/><c>[]</c>.</param>
		/// <returns><see cref="char"/><c>[]</c> array as <see cref="string"/>.</returns>
		public static string CharArrayToString(this char[] chars)
		{
			string ret = "";
			for (int i = 0; i < chars.Length; i++) ret += chars[i];
			return ret;
		}
		/// <summary>
		/// returns count of specified <see cref="char"/> <paramref name="value"/>.
		/// </summary>
		/// <param name="str"><see cref="string"/> where to count <see cref="char"/> <paramref name="value"/>.</param>
		/// <param name="value"><see cref="char"/> that will be counted.</param>
		/// <returns>count of <paramref name="value"/>.</returns>
		public static int CountOfChars(this string str, char value)
		{
			int c = 0;
			for (int i = 0; i < str.Length; i++) if (str[i] == value) c++;
			return c;
		}
		/// <summary>
		/// cut in substring to first <paramref name="symbol"/> in <paramref name="str"/>.<br/>
		/// <paramref name="firstSymbol"/> is postion of <paramref name="symbol"/>. 
		/// </summary>
		/// <param name="str">string to cut.</param>
		/// <param name="symbol">cutting till this symbol in <paramref name="str"/> in returning value.</param>
		/// <param name="firstSymbol">position of this <paramref name="symbol"/>.</param>
		/// <returns><paramref name="str"/> cutted till <paramref name="symbol"/>.</returns>
		public static string CutToFirst(this string str, char symbol, out int firstSymbol)
		{
			string ret = "";
			firstSymbol = -1;
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] != symbol) ret += str[i];
				else
				{
					firstSymbol = i;
					break;
				}
			}
			return ret;
		}
		/// <summary>
		/// adds the <see cref="string"/> <paramref name="value"/> to the end of this string.
		/// </summary>
		/// <param name="str">this string, where will be added <paramref name="value"/></param>
		/// <param name="value">value that will be added to this string.</param>
		/// <returns>this string with appended <paramref name="value"/> to the end.</returns>
		public static string AddToEnd(this string str, string value)
		{
			string outp = "";
			char[] arr = str.ToArray();
			for (int i = 0; i <  value.Length; i++) arr = arr.Append(value[i]).ToArray();
			for (int i = 0; i < arr.Length; i++) outp += arr[i];
			return outp;
		}
	}
}
