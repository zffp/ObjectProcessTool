using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using ObjectProcessTool.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Bil
{
    /// <summary>
    /// 脚本管理
    /// </summary>
    class ScriptManager : Singleton<ScriptManager>
    {
        const string CatalogName = "script";

        public string Applcation { get; private set; }

        public void Init()
        {

            string scriptPath = GetScriptPath();

            if (!Directory.Exists(scriptPath))
            {
                Directory.CreateDirectory(scriptPath);
            }
        }
        public string GetScriptPath()
        {
            string appPath = Directory.GetCurrentDirectory();

            string scriptPath = appPath + "\\" + CatalogName;
            return scriptPath;
        }
        /// <summary>
        /// 保存脚本
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public void SaveScript(string name, string content)
        {
            string scriptPath = GetScriptPath() + "\\" + name + ".py";
            File.WriteAllText(scriptPath, content);
        }

        public string ReadScript(string name)
        {
            string scriptPath = GetScriptPath() + "\\" + name + ".py";
            if (File.Exists(scriptPath))
            {
                return File.ReadAllText(scriptPath);
            }
            return "";
        }
        /// <summary>
        /// 获取所有脚本
        /// </summary>
        public string[] GetAllScript()
        {
            if (!Directory.Exists(GetScriptPath()))
            {
                return new string[0];
            }

            string[] fileList = Directory.GetFiles(GetScriptPath());

            return fileList.Select(r => Path.GetFileNameWithoutExtension(Path.GetFileName(r))).ToArray();
        }

        public Tuple<string,dynamic> GetScriptFunction(string script)
        {
            try
            {
                ScriptEngine pyEngine = Python.CreateEngine();
                ScriptScope scope = pyEngine.CreateScope();
                pyEngine.Execute(script, scope);

                List<string> vns = scope.GetVariableNames().ToList();

                if (vns.Contains("convert"))
                {
                    dynamic convertFunction = scope.GetVariable("convert");

                    return new Tuple<string, dynamic>("convert", convertFunction);
                }
                else if (vns.Contains("select"))
                {
                    dynamic selectFunction = scope.GetVariable("select");
                    return new Tuple<string, dynamic>("select", selectFunction);
                }
            }catch(Exception e)
            {

            }
           

            return null;
        }
    }
}
