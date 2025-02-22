// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.DotNet.Tools.Scaffold.AspNet.Templates.BlazorIdentity.Pages
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class Register : RegisterBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("@page \"/Account/Register\"\r\n\r\n@using System.ComponentModel.DataAnnotations\r\n@using" +
                    " System.Text\r\n@using System.Text.Encodings.Web\r\n@using Microsoft.AspNetCore.Iden" +
                    "tity\r\n@using Microsoft.AspNetCore.WebUtilities\r\n");

if (!string.IsNullOrEmpty(Model.DbContextNamespace))
{

            this.Write("@using ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.DbContextNamespace));
            this.Write("\r\n");
} 
            this.Write("\r\n@inject UserManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> UserManager\r\n@inject IUserStore<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> UserStore\r\n@inject SignInManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> SignInManager\r\n@inject IEmailSender<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> EmailSender\r\n@inject ILogger<Register> Logger\r\n@inject NavigationManager Naviga" +
                    "tionManager\r\n@inject IdentityRedirectManager RedirectManager\r\n\r\n<PageTitle>Regis" +
                    "ter</PageTitle>\r\n\r\n<h1>Register</h1>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-m" +
                    "d-4\">\r\n        <StatusMessage Message=\"@Message\" />\r\n        <EditForm Model=\"In" +
                    "put\" asp-route-returnUrl=\"@ReturnUrl\" method=\"post\" OnValidSubmit=\"RegisterUser\"" +
                    " FormName=\"register\">\r\n            <DataAnnotationsValidator />\r\n            <h2" +
                    ">Create a new account.</h2>\r\n            <hr />\r\n            <ValidationSummary " +
                    "class=\"text-danger\" role=\"alert\" />\r\n            <div class=\"form-floating mb-3\"" +
                    ">\r\n                <InputText @bind-Value=\"Input.Email\" class=\"form-control\" aut" +
                    "ocomplete=\"username\" aria-required=\"true\" placeholder=\"name@example.com\" />\r\n   " +
                    "             <label for=\"email\">Email</label>\r\n                <ValidationMessag" +
                    "e For=\"() => Input.Email\" class=\"text-danger\" />\r\n            </div>\r\n          " +
                    "  <div class=\"form-floating mb-3\">\r\n                <InputText type=\"password\" @" +
                    "bind-Value=\"Input.Password\" class=\"form-control\" autocomplete=\"new-password\" ari" +
                    "a-required=\"true\" placeholder=\"password\" />\r\n                <label for=\"passwor" +
                    "d\">Password</label>\r\n                <ValidationMessage For=\"() => Input.Passwor" +
                    "d\" class=\"text-danger\" />\r\n            </div>\r\n            <div class=\"form-floa" +
                    "ting mb-3\">\r\n                <InputText type=\"password\" @bind-Value=\"Input.Confi" +
                    "rmPassword\" class=\"form-control\" autocomplete=\"new-password\" aria-required=\"true" +
                    "\" placeholder=\"password\" />\r\n                <label for=\"confirm-password\">Confi" +
                    "rm Password</label>\r\n                <ValidationMessage For=\"() => Input.Confirm" +
                    "Password\" class=\"text-danger\" />\r\n            </div>\r\n            <button type=\"" +
                    "submit\" class=\"w-100 btn btn-lg btn-primary\">Register</button>\r\n        </EditFo" +
                    "rm>\r\n    </div>\r\n    <div class=\"col-md-6 col-md-offset-2\">\r\n        <section>\r\n" +
                    "            <h3>Use another service to register.</h3>\r\n            <hr />\r\n     " +
                    "       <ExternalLoginPicker />\r\n        </section>\r\n    </div>\r\n</div>\r\n\r\n@code " +
                    "{\r\n    private IEnumerable<IdentityError>? identityErrors;\r\n\r\n    [SupplyParamet" +
                    "erFromForm]\r\n    private InputModel Input { get; set; } = new();\r\n\r\n    [SupplyP" +
                    "arameterFromQuery]\r\n    private string? ReturnUrl { get; set; }\r\n\r\n    private s" +
                    "tring? Message => identityErrors is null ? null : $\"Error: {string.Join(\", \", id" +
                    "entityErrors.Select(error => error.Description))}\";\r\n\r\n    public async Task Reg" +
                    "isterUser(EditContext editContext)\r\n    {\r\n        var user = CreateUser();\r\n\r\n " +
                    "       await UserStore.SetUserNameAsync(user, Input.Email, CancellationToken.Non" +
                    "e);\r\n        var emailStore = GetEmailStore();\r\n        await emailStore.SetEmai" +
                    "lAsync(user, Input.Email, CancellationToken.None);\r\n        var result = await U" +
                    "serManager.CreateAsync(user, Input.Password);\r\n\r\n        if (!result.Succeeded)\r" +
                    "\n        {\r\n            identityErrors = result.Errors;\r\n            return;\r\n  " +
                    "      }\r\n\r\n        Logger.LogInformation(\"User created a new account with passwo" +
                    "rd.\");\r\n\r\n        var userId = await UserManager.GetUserIdAsync(user);\r\n        " +
                    "var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);\r\n       " +
                    " code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));\r\n        var " +
                    "callbackUrl = NavigationManager.GetUriWithQueryParameters(\r\n            Navigati" +
                    "onManager.ToAbsoluteUri(\"Account/ConfirmEmail\").AbsoluteUri,\r\n            new Di" +
                    "ctionary<string, object?> { [\"userId\"] = userId, [\"code\"] = code, [\"returnUrl\"] " +
                    "= ReturnUrl });\r\n\r\n        await EmailSender.SendConfirmationLinkAsync(user, Inp" +
                    "ut.Email, HtmlEncoder.Default.Encode(callbackUrl));\r\n\r\n        if (UserManager.O" +
                    "ptions.SignIn.RequireConfirmedAccount)\r\n        {\r\n            RedirectManager.R" +
                    "edirectTo(\r\n                \"Account/RegisterConfirmation\",\r\n                new" +
                    "() { [\"email\"] = Input.Email, [\"returnUrl\"] = ReturnUrl });\r\n        }\r\n\r\n      " +
                    "  await SignInManager.SignInAsync(user, isPersistent: false);\r\n        RedirectM" +
                    "anager.RedirectTo(ReturnUrl);\r\n    }\r\n\r\n    private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write(" CreateUser()\r\n    {\r\n        try\r\n        {\r\n            return Activator.Create" +
                    "Instance<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write(">();\r\n        }\r\n        catch\r\n        {\r\n            throw new InvalidOperation" +
                    "Exception($\"Can\'t create an instance of \'{nameof(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write(")}\'. \" +\r\n                $\"Ensure that \'{nameof(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write(")}\' is not an abstract class and has a parameterless constructor.\");\r\n        }\r\n" +
                    "    }\r\n\r\n    private IUserEmailStore<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> GetEmailStore()\r\n    {\r\n        if (!UserManager.SupportsUserEmail)\r\n        {\r" +
                    "\n            throw new NotSupportedException(\"The default UI requires a user sto" +
                    "re with email support.\");\r\n        }\r\n        return (IUserEmailStore<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write(@">)UserStore;
    }

    private sealed class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = ""Email"")]
        public string Email { get; set; } = """";

        [Required]
        [StringLength(100, ErrorMessage = ""The {0} must be at least {2} and at max {1} characters long."", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = ""Password"")]
        public string Password { get; set; } = """";

        [DataType(DataType.Password)]
        [Display(Name = ""Confirm password"")]
        [Compare(""Password"", ErrorMessage = ""The password and confirmation password do not match."")]
        public string ConfirmPassword { get; set; } = """";
    }
}
");
            return this.GenerationEnvironment.ToString();
        }
        private global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost hostValue;
        /// <summary>
        /// The current host for the text templating engine
        /// </summary>
        public virtual global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost Host
        {
            get
            {
                return this.hostValue;
            }
            set
            {
                this.hostValue = value;
            }
        }

private global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel Model
{
    get
    {
        return this._ModelField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ModelValueAcquired = false;
if (this.Session.ContainsKey("Model"))
{
    this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    string parameterValue = this.Host.ResolveParameterValue("Property", "PropertyDirectiveProcessor", "Model");
    if ((string.IsNullOrEmpty(parameterValue) == false))
    {
        global::System.ComponentModel.TypeConverter tc = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel));
        if (((tc != null) 
                    && tc.CanConvertFrom(typeof(string))))
        {
            this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel)(tc.ConvertFrom(parameterValue)));
            ModelValueAcquired = true;
        }
        else
        {
            this.Error("The type \'Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel\' of t" +
                    "he parameter \'Model\' did not match the type of the data passed to the template.");
        }
    }
}
if ((ModelValueAcquired == false))
{
    object data = global::Microsoft.DotNet.Scaffolding.TextTemplating.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.BlazorIdentityModel)(data));
    }
}


    }
}


    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class RegisterBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
