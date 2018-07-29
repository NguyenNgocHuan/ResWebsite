using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class ReflectionController
    {
        public List<Type> GetControllers(string namespaces)
        {
            List<Type> listController = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) &&
             type.Namespace.Contains(namespaces)).OrderBy(x => x.Name);
            return types.ToList();
        }
        /// <summary>
        /// Truyền controller lấy ra các actions
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public List<String> GetActions(Type controller)
        {
            List<String> listAction = new List<string>();
            IEnumerable<MemberInfo> memberInfo = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly |
                BindingFlags.Public).Where(x => !x.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true)
                .Any()).OrderBy(x => x.Name);
            foreach (MemberInfo method in memberInfo)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listAction.Add(method.Name.ToString());
                }
            }
            return listAction;
        }
    }
}