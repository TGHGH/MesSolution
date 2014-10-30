using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto
{
    class Program
    {
        public static readonly string namespaceString = "Core.Db.Repositories";
        public static readonly string namespaceString_BLL = "MESBll3";
        public static readonly string rn = "\r\n";
        public static readonly string space = "    ";
        static void Main(string[] args)
        {

            //Console.WriteLine(ToFirstLower("UserGroup"));
           // writeFile("Mdl");
           // writeFileBLL("UserGroup2Res");
            writeFileCoreIService("Mdl");
            writeFileCoreService("Mdl");
           

        }
        public static void writeFile(string calssString)
        {
            writeFileIDAL(calssString);
            writeFileDAL(calssString);
        }
        public static void writeFileIDAL(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Db/Repositories" + "/I" + classString + "Repository" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                string s = "using System;" + rn;
                s = s + "using System.Collections.Generic;" + rn;
                s = s + "using System.Linq;" + rn;
                s = s + "using System.Text;" + rn;

                s = s + "using Component.Data;" + rn;
                s = s + "using Core.Models;" + rn;
                s = s + rn;
                s = s + "namespace " + namespaceString + rn;
                s = s + "{" + rn;
                s = s + rn;
                s = s + space + "public interface I" + classString + "Repository : IRepository<" + classString + ">" + rn;

                s = s + space + "{" + rn;
                s = s + space + "}" + rn;
                s = s + "}" + rn;


                charData = s.ToCharArray();
                byData = new byte[charData.Length];
                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byData, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return;
            }
        }
        public static void writeFileDAL(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Db/Repositories/Impl" + "/" + classString + "Repository" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                string s = "using System;" + rn;
                s = s + "using System.Collections.Generic;" + rn;
                s = s + "using System.ComponentModel.Composition;" + rn;
                s = s + "using System.Linq;" + rn;
                s = s + "using System.Text;" + rn;
              
                s = s + "using Component.Data;" + rn;
                s = s + "using Core.Models;" + rn;
                s = s + rn;
                s = s + "namespace " + namespaceString + rn;
                s = s + "{" + rn;
                s = s + rn;
                s = s + space + "[Export(typeof(I" + classString + "Repository))]" + rn;
                s = s + space + "public class " + classString + "Repository : EFRepositoryBase<" + classString + ">,I" + classString + "Repository" + rn;

                s = s + space + "{" + rn;
                s = s + space + "}" + rn;
                s = s + "}" + rn;


                charData = s.ToCharArray();
                byData = new byte[charData.Length];
                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byData, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return;
            }
        }
        /// <summary>
        /// 自动生成业务层核心接口
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFileCoreIService(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Service" + "/" + classString + "Service" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                string s = "using System;" + rn;
                s = s + "using Component.Tools;" + rn;
                s = s + "using System.Linq;" + rn;
                s = s + "using System.Text;" + rn;
                s = s + "using Core.Models;" + rn;
              
                s = s + rn;
                s = s + "namespace " + "Core.Service" + rn;
                s = s + "{" + rn;
                s = s + rn;

                //有参数构造函数
                s = s + space + "public interface I" + classString + "Service" + rn;
                s = s + space + "{" + rn;
                s = s + space + space + " OperationResult AddEntity("+classString+" "+classString.ToLower()+");"+  rn;
                s = s + space + space + " OperationResult DeleteEntity(string key);"  + rn;
                s = s + space + space + " OperationResult FindEntity(string key);" + rn;
                s = s + space + space + " OperationResult UpdateEntity(" + classString + " " + classString.ToLower() + ");" + rn;
                s = s + space + space + "IQueryable<"+classString+">"+ classString+"+s();" + rn;
                s = s + space + "}" + rn;
                s = s + "}" + rn;


                charData = s.ToCharArray();
                byData = new byte[charData.Length];
                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byData, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return;
            }
        }
        /// <summary>
        /// 自动生成业务核心层服务
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFileCoreService(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Service" + "/" + classString + "Service" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                string s = "using System.ComponentModel.Composition;" + rn;
                s = s + "using Component.Tools;" + rn;
                s = s + "using System.Linq;" + rn;
                s = s + "using Core.Db.Repositories;" + rn;
                s = s + "using Core.Models;" + rn;

                s = s + rn;
                s = s + "namespace " + "Core.Service" + rn;
                s = s + "{" + rn;
                s = s + rn;

               
                s = s + space + "public abstract class " + classString + "Service" +" : CoreServiceBase,I"+classString+"Service"+ rn;
                s = s + space + "{" + rn;
                s = s + space + space + "[Import]" + rn;
                s = s + s + "protected I"+classString+"Repository "+classString.ToLower()+"Repository { get; set; } " + rn;

                s = s + s + "public IQueryable<" + classString + "> " + classString + "s()" + rn;
                s = s + s + "{" + rn;
                s = s + s + "return "+classString.ToLower()+"Repository.Entities;" + rn;
                s = s + s + "}" + rn;

                s = s + s + "public virtual OperationResult AddEntity("+classString+" " +classString.ToLower()+")" + rn;
                s = s + s + "{" + rn;
                s = s + s + "return "+classString.ToLower()+".Insert("+classString.ToLower()+",true);" + rn;
                s = s + s + "}" + rn;

                s = s + s + "public virtual OperationResult DeleteEntity(string key);" + rn;
                s = s + s + "{" + rn;
                s = s + s + "return " + classString.ToLower() + ".Delete(key,true);" + rn;
                s = s + s + "}" + rn;

                s = s + s + "public virtual OperationResult FindEntity(string key);" + rn;
                s = s + s + "{" + rn;
                s = s + s +"PublicHelper.CheckArgument(key, \""+classString.ToLower()+"\");"+ rn;
                s = s + s + "return " + classString.ToLower() + ".GetByKey(key);" + rn;
                s = s + s + "}" + rn;

                s = s + s + "public virtual OperationResult UpdateEntity(" + classString + " " + classString.ToLower() + ")" + rn;
                s = s + s + "{" + rn;
                s = s + s + "return " + classString.ToLower() + ".Update(" + classString.ToLower() + ",true);" + rn;
                s = s + s + "}" + rn;                
                
                s = s + space + "}" + rn;
                s = s + "}" + rn;


                charData = s.ToCharArray();
                byData = new byte[charData.Length];
                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byData, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byData, 0, byData.Length);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return;
            }
        }

        /// <summary>
        /// 把字符串的第一个字母改成小写
        /// </summary>
        /// <param name="classString"></param>
        /// <returns></returns>
        public static string ToFirstLower(string classString)
        {
            return classString.Substring(0, 1).ToLower()+classString.Substring(1);
        }
    }

}
