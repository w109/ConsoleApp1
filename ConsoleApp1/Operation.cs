using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算2._0
{
     public class Operation
    {
        /// <summary>
        /// 用于生产公式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="number">自然数随机</param>
        /// <param name="difficulty">取值最大值</param>
        /// <param name="operatos">用于显示的运算符数组</param>
        /// <param name="operatos1">用于计算的运算符数组</param>
        /// <param name="shu">用于判断运算公式是几则</param>
        /// <returns></returns>

        public static string formula(DataTable dt, Random number, int difficulty, string[] operatos, string[] operatos1,int shu)
        {
            string number1 = number.Next(0, difficulty).ToString();//运算公式自然数
            string results= number1;//用于输出
            string results1 = number1;//用于计算
            for (int s=0;s< shu; s++)
            {
                int number_op = number.Next(0, 4);//随机一次运算符
                number1 = number.Next(1, difficulty).ToString();//随机一个自然数
                results += operatos[number_op]+number1;//把运算符和自然数添加进用于计算的字符串
                results1 += operatos1[number_op]+number1;//把运算符和自然数添加进用于输出的字符串
            }
            double st = double.Parse(dt.Compute(results1,"null").ToString());//计算字符串类型公式的结果
            results += "=" + st.ToString();//把运算结果添加输出字符串
            if (st < 0 || st.ToString() == "∞")//判断结果 如果小于0或无穷大 则重新运行一次
            {
                results = formula(dt, number, difficulty, operatos, operatos1, shu);
            }         
           
            return results;//把最终的输出公式返回
        }
    }
}
