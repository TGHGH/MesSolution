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
        //public static readonly string namepaceRepositorie"Core.Db.Repositories";
        //public static readonly string name = "MESBll3";
        //public static readonly string rn = "\r\n";
        //public static readonly string "\t" = "    ";
        static void Main(string[] args)
        {

            //Console.WriteLine(ToFirstLower("UserGroup"));
           // writeFile("Mdl");
           // writeFileBLL("UserGroup2Res");
            writeFileFormIService("Res");
            writeFileFormService("Res");          

        }
        # region  writeFile自动生成DAL文件
        /// <summary>
        /// 同时生产多个文件函数
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFile(string classString)
        {
            writeFileIDAL(classString);
            writeFileDAL(classString);
            writeFileCoreIService(classString);
            writeFileCoreService(classString);
        }
        #endregion
        #region writeFileIDAL自动生成DAL文件
        /// <summary>
        /// 自动生成IDAL文件
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFileIDAL(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Db/Repositories" + "/I" + classString + "Repository" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                StringBuilder s =new StringBuilder( "using System;" );
                s.AppendLine( "using System.Collections.Generic;" );
                s.AppendLine( "using System.Linq;" );
                s.AppendLine( "using System.Text;" );

                s.AppendLine( "using Component.Data;" );
                s.AppendLine( "using Core.Models;" );
                s.AppendLine();
                s.AppendLine( "namespace Core.Db.Repositories" );
                s.AppendLine( "{" );
                s.AppendLine();
                s.AppendLine( "\t" + "public interface I" + classString + "Repository : IRepository<" + classString + ">" );

                s.AppendLine( "\t" + "{" );
                s.AppendLine( "\t" + "}" );
                s.AppendLine( "}" );


                charData = s.ToString().ToCharArray();
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
        #endregion
        #region writeFileDAL自动生成DAL文件
        /// <summary>
        /// 自动生成DAL文件
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFileDAL(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Db/Repositories/Impl" + "/" + classString + "Repository" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                StringBuilder s =new StringBuilder ("using System;" );
                s.AppendLine( "using System.Collections.Generic;" );
                s.AppendLine( "using System.ComponentModel.Composition;" );
                s.AppendLine( "using System.Linq;" );
                s.AppendLine( "using System.Text;" );
              
                s.AppendLine( "using Component.Data;" );
                s.AppendLine( "using Core.Models;" );
                s.AppendLine();
                s.AppendLine( "namespace Core.Db.Repositories");
                s.AppendLine( "{" );
                s.AppendLine();
                s.AppendLine( "\t" + "[Export(typeof(I" + classString + "Repository))]" );
                s.AppendLine( "\t" + "public class " + classString + "Repository : EFRepositoryBase<" + classString + ">,I" + classString + "Repository" );

                s.AppendLine( "\t" + "{" );
                s.AppendLine( "\t" + "}" );
                s.AppendLine( "}" );


                charData = s.ToString().ToCharArray();
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
        #endregion
        #region writeFileCoreIService自动生成业务层核心接口
        /// <summary>
        /// 自动生成业务层核心接口
        /// </summary>
        /// <param name="classString"></param>
        public static void writeFileCoreIService(string classString)
        {

            FileStream aFile = new FileStream("../../../" + "Core.Service" + "/I" + classString + "Service" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;
            try
            {
                StringBuilder s =new StringBuilder ("using System;") ;
                s.AppendLine();
                s.AppendLine("using Component.Tools;");
                s.AppendLine("using System.Linq;");
                s.AppendLine("using System.Text;");
                s.AppendLine("using Core.Models;");

                s.AppendLine();
                s.AppendLine("namespace " + "Core.Service");
                s.AppendLine( "{");
                s.AppendLine();

                //有参数构造函数
                s.AppendLine("\t"+"public interface I" + classString + "Service") ;
                s.AppendLine( "\t" + "{" );
                s.AppendLine( "\t" + "\t" + " OperationResult AddEntity("+classString+" "+ToFirstLower(classString)+");");
                s.AppendLine( "\t" + "\t" + " OperationResult DeleteEntity(string key);"  );
                s.AppendLine( "\t" + "\t" + " OperationResult FindEntity(string key);" );
                s.AppendLine( "\t" + "\t" + " OperationResult UpdateEntity(" + classString + " " + ToFirstLower(classString) + ");" );
                s.AppendLine( "\t" + "\t" + " IQueryable<"+classString+">"+ classString+"s( );" );
                s.AppendLine( "\t" + "}" );
                s.AppendLine( "}" );
                

                charData = s.ToString().ToCharArray();
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
        #endregion
        #region writeFileCoreService自动生成业务核心层服务

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
                StringBuilder s =new StringBuilder ("using System.ComponentModel.Composition;" );
                s.AppendLine();
                s.AppendLine( "using Component.Tools;" );
                s.AppendLine( "using System.Linq;" );
                s.AppendLine( "using Core.Db.Repositories;" );
                s.AppendLine( "using Core.Models;" );

               
                s.AppendLine( "namespace " + "Core.Service" );
                s.AppendLine( "{" );
                 s.AppendLine();

               
                s.AppendLine( "\t" + "public abstract class " + classString + "Service" +" : CoreServiceBase,I"+classString+"Service");
                s.AppendLine( "\t" + "{" );
                s.AppendLine( "\t" + "\t" + "[Import]" );
                s.AppendLine( "\t" + "\t" + "protected I" + classString + "Repository " + ToFirstLower(classString) + "Repository { get; set; } ");

                s.AppendLine( "\t" + "\t" + "public IQueryable<" + classString + "> " + classString + " s()");
                s.AppendLine( "\t" + "\t" + "{");
                s.AppendLine("\t" + "\t" + "\t" + "return " +ToFirstLower(classString) + "Repository.Entities;");
                s.AppendLine( "\t" + "\t" + "}");

                s.AppendLine("\t" + "\t" + "public virtual OperationResult AddEntity(" + classString + " " + ToFirstLower(classString) + ")");
                s.AppendLine("\t" + "\t" + "{");
                s.AppendLine("\t" + "\t" + "\t" + "return " + ToFirstLower(classString) + "Repository.Insert(" + ToFirstLower(classString) + ",true);");
                s.AppendLine("\t" + "\t" + "}");

                s.AppendLine("\t" + "\t" + "public virtual OperationResult DeleteEntity(string key)");
                s.AppendLine("\t" + "\t" + "{");
                s.AppendLine("\t" + "\t" + "\t" + "return " + ToFirstLower(classString) + "Repository.Delete(key,true);");
                s.AppendLine("\t" + "\t" + "}");

                s.AppendLine("\t" + "\t" + "public virtual OperationResult FindEntity(string key)");
                s.AppendLine("\t" + "\t" + "{");
                s.AppendLine("\t" + "\t" + "\t" + "PublicHelper.CheckArgument(key, \"" + ToFirstLower(classString) + "\");");
                s.AppendLine("\t" + "\t" + "\t" + "return " + ToFirstLower(classString) + "Repository.GetByKey(key);");
                s.AppendLine("\t" + "\t" + "}");

                s.AppendLine("\t" + "\t" + "public virtual OperationResult UpdateEntity(" + classString + " " + ToFirstLower(classString) + ")");
                s.AppendLine("\t" + "\t" + "{");
                s.AppendLine("\t" + "\t" + "\t" + "return " + ToFirstLower(classString) + "Repository.Update(" + ToFirstLower(classString) + ",true);");
                s.AppendLine("\t" + "\t" + "}");                
                
                s.AppendLine( "\t" + "}" );
                s.AppendLine( "}" );


                charData = s.ToString().ToCharArray();
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
        #endregion
        #region ToFirstLower转换单词函数（第一个字母变小写）

        /// <summary>
        /// 把字符串的第一个字母改成小写
        /// </summary>
        /// <param name="classString"></param>
        /// <returns></returns>
        public static string ToFirstLower(string classString)
        {
            return classString.Substring(0, 1).ToLower()+classString.Substring(1);
        }
        #endregion

        #region writeFileFormIService自动生成FormIService函数

        public static void writeFileFormIService(string classString)
        {
            FileStream aFile = new FileStream("../../../" + "Form.Service" + "/I" + classString + "FormService" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;           

            try
            {
                StringBuilder s = new StringBuilder("using Core.Service;");
                s.AppendLine();
                s.AppendLine("using System;");              

                s.AppendLine();
                s.AppendLine("namespace " + "FormApplication.Service");
                s.AppendLine("{");
                s.AppendLine();

                //有参数构造函数
                s.AppendLine("\t" + "public interface I" + classString + "FormService : I" + classString+"Service");
                s.AppendLine("\t" + "{");
                s.AppendLine();
                s.AppendLine("\t" + "}");
                s.AppendLine("}");


                charData = s.ToString().ToCharArray();
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

        #endregion

        #region writeFileFormService自动生成FormService函数
        private static void writeFileFormService(string classString)
        {
            FileStream aFile = new FileStream("../../../" + "Form.Service" + "/" + classString + "FormService" + ".cs", FileMode.Create);
            byte[] byData;
            char[] charData;

            try
            {
                StringBuilder s = new StringBuilder("using Core.Service;");
                s.AppendLine();
                s.AppendLine("using System;");
                s.AppendLine("using System.ComponentModel.Composition;");

                s.AppendLine();
                s.AppendLine("namespace " + "FormApplication.Service");
                s.AppendLine("{");
                s.AppendLine();
                s.AppendLine("\t" +"[Export(typeof(I"+classString+"FormService))]");
                //有参数构造函数
                s.AppendLine("\t" + "public class " + classString + "FormService : " + classString + "Service ,I" + classString + "FormService");
                s.AppendLine("\t" + "{");
                s.AppendLine();
                s.AppendLine("\t" + "}");
                s.AppendLine("}");


                charData = s.ToString().ToCharArray();
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
        #endregion

    }

}
