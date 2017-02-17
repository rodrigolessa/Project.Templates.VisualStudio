using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Microsoft.AspNet.Scaffolding;

namespace NgScaffold
{
    [Export(typeof(CodeGeneratorFactory))]
    public class NgCodeGeneratorFactory : CodeGeneratorFactory
    {
        private static ImageSource _icon = Imaging.CreateBitmapSourceFromHIcon(
            Imagens.Ngear_24.Handle,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

        private static CodeGeneratorInformation _info = new CodeGeneratorInformation(
            displayName: ".Net AngularJS Scaffold",
            description: "AngularJS custom Scaffolder for ASP.Net MVC",
            author: "Rodrigo Lessa",
            version: new Version(1, 0, 0, 0),
            id: typeof(NgCodeGenerator).Name,
            icon: _icon,
            gestures: new[] { "Mvc" },
            categories: new[] { Categories.Common, Categories.Mvc, Categories.MvcController, Categories.Other });

        public NgCodeGeneratorFactory() : base(_info) { }

        #region Member of CodeGeneratorFactory

        public override ICodeGenerator CreateInstance(CodeGenerationContext context)
        {
            return new NgCodeGenerator(context, Information);
        }

        #endregion

        public override bool IsSupported(CodeGenerationContext codeGenerationContext)
        {
            if (codeGenerationContext.ActiveProject.CodeModel.Language != EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp)
                return false;

            return true;
        }
    }
}
