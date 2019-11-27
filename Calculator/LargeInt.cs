using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class LargeInt
    {
        private string number;
        private string value;
        private bool isPositive;

        public LargeInt(string number)
        {
            this.number = number;

            if (number[0] == '-')
            {
                isPositive = false;
                number = number.Replace("-",string.Empty);
            }
            else isPositive = true;
                
            this.value = number;
        }

        public LargeInt(int number)
        {
            this.number = number.ToString();
            this.value = Math.Abs(number).ToString();
            this.isPositive = (number >= 0);
        }

        public LargeInt setPositive(bool isPos)
        {
            LargeInt ans = this;
            if (isPos)
            {
                ans.number = ans.value;
                ans.isPositive = true;
            }
            else
            {
                ans.number = "-" + ans.value;
                ans.isPositive = false;
            }
            return ans;
        }

        public LargeInt plus(LargeInt value)
        {
            LargeInt num1 = this;
            LargeInt num2 = value;
            string result;

            if(num1.isPositive == num2.isPositive)
            {
                result = sumTwoStrings(num1.value, num2.value, num1.isPositive);
            }
            else
            {
                return minus(num2.flip());
            }
            return new LargeInt(result);
        }

        public LargeInt minus(LargeInt value)
        {
            if (isPositive != value.isPositive)
            {
                return plus(value.flip());
            }

            LargeInt biggest, smallest;

            //Определяем большее по модулю число
            if (value.value.Length == this.value.Length)
            {
                int i = 0;
                while (true)
                {
                    if (i < this.value.Length)
                    {
                        if (this.value[i] != value.value[i])
                        {
                            if (this.value[i] - '0' > value.value[i] - '0')
                            {
                                biggest = this;
                                biggest.isPositive = isPositive;
                                smallest = value;
                                if (i > 1)
                                {
                                    biggest.value = biggest.value.Remove(0, i - 1);
                                    smallest.value = smallest.value.Remove(0, i - 1);
                                }
                                else
                                {
                                    biggest.value = biggest.value.Remove(0, i);
                                    smallest.value = smallest.value.Remove(0, i);
                                }
                                
                                break;
                            }
                            else
                            {
                                biggest = value;
                                biggest.isPositive = false;
                                smallest = this;

                                if (i > 1)
                                {
                                    biggest.value = biggest.value.Remove(0, i - 1);
                                    smallest.value = smallest.value.Remove(0, i - 1);
                                }
                                else
                                {
                                    biggest.value = biggest.value.Remove(0, i);
                                    smallest.value = smallest.value.Remove(0, i);
                                }

                                break;
                            }
                        }
                    } else
                    {
                        return new LargeInt("0");   //в случае равенства чисел
                    }
                    i++;
                }
            }
            else
            {
                if (value.value.Length > this.value.Length)
                {
                    biggest = value;
                    biggest.isPositive = false;
                    smallest = this;
                }
                else
                {
                    biggest = this;
                    biggest.isPositive = isPositive;
                    smallest = value;
                }
            }

            string bignum = biggest.value; 
            string smallnum = smallest.value;

            if (bignum.Length < 20)  //Если помещается в UInt64, то считаем напрямую
            {
                if(biggest.isPositive)
                    return new LargeInt("" + (UInt64.Parse(bignum)-UInt64.Parse(smallnum)));
                else return new LargeInt("-" + (UInt64.Parse(bignum) - UInt64.Parse(smallnum)));
            }
            else //Иначе делим по 18 порядков
            {
                StringBuilder result = new StringBuilder();
                int difference = bignum.Length - smallnum.Length;
                bool reminder = false;
                int n = 18;


                while (smallnum.Length>0)
                {

                    while (bignum.Length < n)
                    {
                        bignum = "0" + bignum;
                    }

                    while (smallnum.Length < n)
                    {
                        smallnum = "0" + smallnum;
                    }

                    int i = bignum.Length - n;
                    int j = smallnum.Length - n;
                    UInt64 first = UInt64.Parse(bignum.Substring(i, n));
                    UInt64 second = UInt64.Parse(smallnum.Substring(j, n));
                    string dif;

                    if (reminder)       //Подбираем 18 порядков с учётом остатка
                    {
                        first--;
                        reminder = false;

                        if (first < second)
                        {
                            first = UInt64.Parse("1" + bignum.Substring(i, n)) - 1;
                            reminder = true;
                        }
                    }
                    else
                    {
                        if (first < second)
                        {
                            first = UInt64.Parse("1" + bignum.Substring(i, n));
                            reminder = true;
                        }           
                    }

                    dif = "" + (first - second);

                    while (dif.Length < n)
                    {
                        dif = "0" + dif;
                    }

                    result.Insert(0, dif); //сохраняем результат

                    smallnum = smallnum.Remove(j, n);  //откидываем рассмотренные промежутки
                    bignum = bignum.Remove(i, n);
                }

                if (bignum.Length != 0)
                {
                    result.Insert(0, bignum.Substring(0, bignum.Length - 1));
                }


                if (biggest.isPositive)
                    return new LargeInt(deleteZeroes(result.ToString()));
                else return new LargeInt("-"+ deleteZeroes(result.ToString()));
            }

        }

        public LargeInt multyply(LargeInt value)
        {
            string first = this.value;
            string second = value.value;
            StringBuilder answer = new StringBuilder("0");
            bool isPos = isPositive == value.isPositive;

            if (first == "0" || second == "0")
                return new LargeInt(0);

            if (first == "1")
                return new LargeInt(second);

            if (second == "1")
                return new LargeInt(first);

            if (first.Length * second.Length <= 19)
            {
                answer.Replace(answer.ToString(),(UInt64.Parse(first) * UInt64.Parse(second)).ToString());
            }
            else
            {
                

                for (int i = first.Length - 1; i >= 0; i--)
                {
                    List<int> sum = new List<int>();
                    int carry = 0;

                    for (int j = second.Length - 1; j >= 0; j--)
                    {
                        if ((first[i]-'0') * (second[j]-'0') + carry < 10)
                        {
                            sum.Insert(0, (first[i] - '0') * (second[j] - '0') + carry);
                        }
                        else
                        {
                            sum.Insert(0, ((first[i] - '0') * (second[j] - '0') + carry)%10);
                            carry = ((first[i] - '0') * (second[j] - '0') + carry) / 10;
                        }
                    }

                    if (carry != 0)
                        sum.Insert(0, carry);

                    for (int k = first.Length - 1; k > i; k--)
                        sum.Add(0);

                     answer.Replace(answer.ToString(),amount(answer.ToString(), ToString(sum)));
                }

                answer.Replace(answer.ToString(), deleteZeroes(answer.ToString()));
            }

            if (!isPos)
                answer.Insert(0, '-');

            return new LargeInt(answer.ToString());
        }

        public LargeInt divide(LargeInt value)
        {
            string first = this.value;
            string second = value.value;
            bool isPos = value.isPositive == isPositive;

            if(first == second)
                return new LargeInt("1").setPositive(isPos);

            if (second == "0")
                throw new DivideByZeroException("Деление на ноль!");

            if (second == "1")
                return new LargeInt(first).setPositive(isPos);

            if (first.Length < second.Length)
                return new LargeInt("0");

            if (first.Length < 20)
                return new LargeInt((UInt64.Parse(first) / UInt64.Parse(second)).ToString());
            else
            {
                string carry = "";
                string answer = "";
                for (int i = 0; i < first.Length; i++)
                {
                    int j = 0;
                    carry += first[i];
                    while (!isSmaller(carry, second))
                    {
                        carry = new LargeInt(carry).minus(new LargeInt(second)).ToString();
                        j++;
                    }
                    answer += j;
                    if (carry == "0")
                        carry = "";
                }
                return new LargeInt(deleteZeroes(answer)).setPositive(isPos);
            }

        }

        public LargeInt factorial()
        {
            if (!isPositive)
                throw new ArgumentOutOfRangeException("Факториал от отрицательного числа не существует");

            if (value.Length == 1)
                if (Int16.Parse(value) == 0 || Int16.Parse(value) == 1)
                    return new LargeInt("1");

            int n = Int32.Parse(value);

            List<int> num = new List<int>();
            num.Add(1);

            int total, remainder = 0;

            for (int i = 2; i <= n; i++)
            {
                for (int j = num.Count - 1; j >= 0; j--)
                {
                    total = i * num[j] + remainder;
                    if (total < 10)
                    {
                        num[j] = total;
                        remainder = 0;
                    }
                    else
                    {
                        num[j] = total % 10;
                        remainder = total / 10;
                    }
                }
                if (remainder > 0)
                {
                    while (remainder > 0)
                    {
                        num.Insert(0, remainder % 10);
                        remainder /= 10;
                    }
                }
            }

            StringBuilder answer = new StringBuilder(ToString(num));

            return new LargeInt(answer.ToString());
        }

        private string sumTwoStrings(string first, string second, bool isPositive)
        {
            StringBuilder biggest, smallest;

            if (first.Length > second.Length) //определяем наибольшее
            {
                biggest = new StringBuilder(first);
                smallest = new StringBuilder(second);
            }
            else
            {
                biggest = new StringBuilder(second);
                smallest = new StringBuilder(first);
            }

            if (biggest.Length < 19)    //Если помещается в UInt64, то считаем напрямую
                if (isPositive)
                    return "" + (UInt64.Parse(biggest.ToString()) + UInt64.Parse(smallest.ToString()));
                else return "-" + (UInt64.Parse(biggest.ToString()) + UInt64.Parse(smallest.ToString()));

            int dif = biggest.Length - smallest.Length;
            int remainder = 0;

            smallest.Insert(0, "0", dif); //добавляем незначимые нули

            StringBuilder result = new StringBuilder(); //строка для записи результата

            for (int i = biggest.Length-1; i >= 0; i--) //подсчёт "столбиком"
            {
                int sum = (biggest[i] - '0') + (smallest[i] - '0') + remainder;
                if (sum < 10)
                {
                    result.Insert(0, sum);
                    remainder = 0;
                }
                else
                {
                    result.Insert(0, sum % 10);
                    remainder = sum / 10;
                }
            }
            if (remainder > 0)                  //добавляем остаток
                result.Insert(0, remainder);

            if (!isPositive)                //приписываем знак
                result.Insert(0, '-');

            return result.ToString();
        }

        private string amount(string s1, string s2)
        {
            LargeInt first = new LargeInt(s1);
            LargeInt second = new LargeInt(s2);

            return first.plus(second).ToString();
        }

        override public string ToString()
        {
            return this.number;
        }

        private bool isBigger(string number1, string number2)
        {
            number1 = deleteZeroes(number1);
            number2 = deleteZeroes(number2);
            if (number1.Length > number2.Length)
                return true;
            if (number1.Length < number2.Length)
                return false;

            int i = 0;
            while (i<number1.Length)
            {
                if (number1[i] > number2[i])
                    return true;

                if (number1[i] < number2[i])
                    return false;
                i++;
            }
            return false;
        }

        private bool isSmaller(string number1, string number2)
        {
            number1 = deleteZeroes(number1);
            number2 = deleteZeroes(number2);
            if (number1 == "")
                return true;
            if (number2 == "")
                return false;

            if (number1.Length < number2.Length)
                return true;
            if (number1.Length > number2.Length)
                return false;

            int i = 0;
            while (i < number1.Length)
            {
                if (number1[i] < number2[i])
                    return true;

                if (number1[i] > number2[i])
                    return false;
                i++;
            }
            return false;
        }

        private string deleteZeroes(string number)
        {
            if (number == "")
                return "";
            while (number[0] == '0')
            {
                number = number.Remove(0, 1);
                if (number.Length == 0)
                    return "";
            }
            return number;
        }

        public LargeInt flip()
        {
            if (isPositive)
            {
                number = "-" + value;
            }
            else
            {
                number = value;
            }

            isPositive = !isPositive;

            return this;
        }

        public string ToString(List<int> list)
        {
            StringBuilder answer = new StringBuilder();

            foreach (int item in list)
            {
                answer.Append(item);
            }

            return answer.ToString();
        }

    }
}
