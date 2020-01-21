
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace test1
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The Recording1 recording.
    /// </summary>
    [TestModule("63cb9dde-204d-4e49-91dd-b387fbd2abb2", ModuleType.Recording, 1)]
    public partial class Recording1 : ITestModule
    {
       //all constants of the project
        public static class CONST
        {
      
            public const string CONNECTED_DEVICE_NAME = "emulator-5554";
            public const string SIGN_UP_EMAIL = "abcdefgh@gmail.com";
            public const string EMAIL = "moiseev.yoav@gmail.com";
            public const string VERIFICATION_CODE = "1234";
            public const string USER_NAME = "moiseev.yoav@gmail.com";
            public const string PASSWORD = "Ymoiseev";
            public const string MANAUL_VALUE = "1800";
            public const string REGISTRATION_NAME = "Moiseev Yoav";
            public const string REGISTRATION_PHONE = "0548467679";
            public const int REGISTRATION_DIABET_INDEX = 100;
            public const int REGISTRATION_COUNTY_CODE_INDEX = 3; // 100-for all posibilities
            public const int SEARCH_TIMEOUT = 10000;



        }



        class Dario
        {
            /// <summary>
            /// Setting Ranorex default test parameters
            /// </summary>
            /// <returns>1 on success</returns>
            public void SetDefaults()
            {
                Mouse.DefaultMoveTime = 300;
                Keyboard.DefaultKeyPressTime = 20;
                Delay.SpeedFactor = 1.00;

                
            }


            /// <summary>
            /// Starting the Application Under Test
            /// </summary>
            /// <param name="ConnectedDeviceName"></param>
            /// <param name="RestartApp">true- to restart the application every time</param>
            /// <returns></returns>
            public int StartApp(string ConnectedDeviceName, bool RestartApp = true)
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Starting Application... on-" + ConnectedDeviceName);
                    Host.Local.RunMobileApp(ConnectedDeviceName, "com.labstyle.darioandroid", RestartApp);
                    Delay.Milliseconds(5000);

                    Report.Log(ReportLevel.Info, "The application started succesfully.");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Application Starting Failed!!!!");
                    return (0);
                }
            }

            /// <summary>
            /// Left gesture on first page to acces Login and SignUp butttons
            /// </summary>
            /// <returns></returns>
            public int LeftGesture()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Performing left gesture to access logIn and SignUp buttons...");
                    repo.ComLabstyleDarioandroid.Linear.Swipe(Location.Center, ValueConverter.ArgumentFromString<Ranorex.Core.Recorder.Touch.GestureDirection>("SwipeDirection", "Right (0°)"), ValueConverter.ArgumentFromString<Ranorex.Core.Distance>("Distance", "1.0"), ValueConverter.ArgumentFromString<Ranorex.Duration>("SwipeDuration", "500ms"), 0);
                    Delay.Milliseconds(500);


                    Report.Log(ReportLevel.Info, "Left gesture performed succesfully. ");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Left gesture to access logIn and SignUp buttons-FAILED!");
                    return (0);
                }

            }

            public int SignUp(string userName, string password)
            {
                try
                {

                    Report.Log(ReportLevel.Info, "Starting SignUP process...");
                    repo.ComLabstyleDarioandroid.WelcomeGetStartedSignUpButton.DoubleTap();
                    Delay.Milliseconds(300);

                   
                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi.DoubleTap();
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi.Element.SetAttributeValue("Text", userName);
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi1.DoubleTap();
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi1.Element.SetAttributeValue("Text", password);
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi2.DoubleTap();
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi2.Element.SetAttributeValue("Text", password);
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.SignUpNextButton.Touch(); 
                    Delay.Milliseconds(2000);

                    


                    Report.Log(ReportLevel.Info, "Set value", "Setting attribute Text to " + CONST.REGISTRATION_NAME + " on item 'ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi3'.", repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi3Info, new RecordItemIndex(29));
                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi3.Element.SetAttributeValue("Text", CONST.REGISTRATION_NAME);
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "SignUp FIRST page succesfully passed with username-" + userName + "  password-" + password); 


                    repo.ComLabstyleDarioandroid.Linear1.ComLabstyleDarioandroidCustomFontEdi4.Element.SetAttributeValue("Text", CONST.REGISTRATION_PHONE);
                    Delay.Milliseconds(200);


                    this.SelectDiabetType(CONST.REGISTRATION_DIABET_INDEX);

                    this.SelectCountryCode(CONST.REGISTRATION_COUNTY_CODE_INDEX);

                    


                    // ----------TAP Create My accaunt--------
                    repo.ComLabstyleDarioandroid.RegistrationPageContainer.SignUpCreateAccountButton.Touch();
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "SignUp SECOND page succesfully passed. Diabet Index-" + CONST.REGISTRATION_DIABET_INDEX + "  ,Country Code-" + CONST.REGISTRATION_COUNTY_CODE_INDEX);



                    //----------------Insert 4 didit code
                    repo.ComLabstyleDarioandroid.RegistrationPageContainer.SingInLastScreenVerificationCodeEd.Element.SetAttributeValue("Text", CONST.VERIFICATION_CODE);
                    Delay.Milliseconds(2000);
                    Report.Log(ReportLevel.Info, "SignUp THIRD page succesfully passed. Verefication Code-" + CONST.VERIFICATION_CODE);


                    Report.Log(ReportLevel.Info, "Trainnig mode- Rolling Back the SignUp process...");

                    repo.ComLabstyleDarioandroid.NotificationHeaderBackButton.Touch();
                    Delay.Milliseconds(900);

                    repo.ComLabstyleDarioandroid.NotificationHeaderBackButton.Touch();
                    Delay.Milliseconds(900);

                    repo.ComLabstyleDarioandroid.NotificationHeaderBackButton.Touch();
                    Delay.Milliseconds(900);

                   
                    repo.ComLabstyleDarioandroid.Linear.Swipe(Location.Center, ValueConverter.ArgumentFromString<Ranorex.Core.Recorder.Touch.GestureDirection>("SwipeDirection", "Right (0°)"), ValueConverter.ArgumentFromString<Ranorex.Core.Distance>("Distance", "1.0"), ValueConverter.ArgumentFromString<Ranorex.Duration>("SwipeDuration", "500ms"), 0);
                    Delay.Milliseconds(500);

                    Report.Log(ReportLevel.Info, "The SignUp process completed succesfully.");

                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "LogIn operation Failed!!!");
                    return (0);
                }
            }

            /// <summary>
            /// Login with specif user credentials
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            /// <returns></returns>
            public int LogIn(string userName, string password)
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Starting SignIn process... userName-" + userName + "  password-" + password);
                    repo.ComLabstyleDarioandroid.WelcomeGetStartedLoginButton.DoubleTap();
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.GetStartedSettingsContainerView.EditText.Element.SetAttributeValue("Text", userName);
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.GetStartedSettingsContainerView.EditText1.Element.SetAttributeValue("Text", password);
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.GetStartedSettingsContainerView.Linear1.Touch();
                    Delay.Milliseconds(3000);

                    Report.Log(ReportLevel.Info, "SignIn process completed succesfuly." );
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "LogIn oppeartion failed!!!");
                    this.StartApp(CONST.CONNECTED_DEVICE_NAME, true);
                    return (0);
                }
            }

            /// <summary>
            /// Click the red plus(+) icon on main page to enter to manual measurment
            /// </summary>
            /// <returns></returns>
            public int TapPLUS()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Tapping the red plus icon...");
                    repo.ComLabstyleDarioandroid.Plus.DoubleTap();
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "Tapping the red plus completed succesfuly.");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Tapping the red plus icon failed!!!");
                    return (0);
                }
            }

            /// <summary>
            /// Tap on "ADD" icon to add manual mesurement
            /// </summary>
            /// <returns></returns>
            public int TapAdd()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Tapping the -ADD- icon...");
                    repo.ComLabstyleDarioandroid.QdeAddGlucoseManuallyButton.Touch();
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "Tapping the -ADD- icon completed succesfuly.");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Tapping the -ADD- icon failed!!!");
                    return (0);
                }


            }

            /// <summary>
            /// Entering the manual measurment value
            /// </summary>
            /// <param name="value"> from 20 to 600</param>
            /// <returns></returns>
            public int AddManualValue(string value)
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Adding manual measurment... value-" + value);

                    repo.ComLabstyleDarioandroid.FetValue.Element.SetAttributeValue("Text", value);
                    Delay.Milliseconds(300);


                    repo.ComLabstyleDarioandroid.GlucoseValueLayout.Touch();
                    Delay.Milliseconds(300);

             
                    repo.ComLabstyleDarioandroid.TabDarioActivity.DoneButton.Touch();
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "Adding manual measurment completed succesfuly.");

                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Entering -" + value + "- failed!!!");
                    return (0);

                }
            }

            /// <summary>
            /// Close popUp page with red -x- icon on top right- if exist
            /// </summary>
            /// <returns></returns>
            public int ClosePopUpMenu()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Closing pop up window if exist...");

                    Delay.Milliseconds(2000);

                    repo.SearchTimeout = CONST.SEARCH_TIMEOUT;
                    repo.ParentFolder.SearchTimeout = CONST.SEARCH_TIMEOUT;

                    Report.Log(ReportLevel.Info, "Touch", "Touch item 'ComLabstyleDarioandroid.TabDarioActivity.RatePopupCloseButton' at Center", repo.ComLabstyleDarioandroid.TabDarioActivity.RatePopupCloseButtonInfo, new RecordItemIndex(22));
                    repo.ComLabstyleDarioandroid.TabDarioActivity.RatePopupCloseButton.Touch();
                    Delay.Milliseconds(300);

                    Report.Log(ReportLevel.Info, "Closing pop up window- completed succesfuly.");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Info, "PopUp page with red -x- not found");
                    return (0);
                }
            }


            /// <summary>
            /// Log out from the application-!!!NO work around found yet
            /// </summary>
            /// <returns></returns>
            public int LogOut()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "Starting LogOut process..."); 
                    repo.ComLabstyleDarioandroid.TabDarioActivity.MenuButton.Touch();
                    Delay.Milliseconds(3000);

                    int status =this.TapSetingsAcountInformation();

                    repo.ComLabstyleDarioandroid.TabDarioActivity.LogOutButton.Touch();
                    Delay.Milliseconds(300);

                    repo.ComLabstyleDarioandroid.ButtonOk.Touch();
                    Delay.Milliseconds(5000);//important

                    if (status == 1)
                    {
                        Report.Log(ReportLevel.Info, "LogOut process completed succesfuly.");
                        return (1);
                    }
                    else
                    {
                        Report.Log(ReportLevel.Failure, "!!!The logOut opperation failed!!!");
                        return (0);
                    }
       
                }
                catch
                {

                    Report.Log(ReportLevel.Failure, "!!!The logOut opperation failed!!!");
                    return (0);
                }
            }


            /// <summary>
            /// REGISTRATION menu -Select diabet type from menu
            /// </summary>
            /// <param name="index">index of item starts with-0, default 100- means -all</param>
            /// <returns></returns>
            public int SelectDiabetType(int index = 100)
            {
                try
                {
                    Report.Log(ReportLevel.Info, "     Start selecting diabet type process...  index-" + index);
                    if (index == 0 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.Linear1.SignUpDiabetesTypeSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Text11.Touch();
                        Delay.Milliseconds(300);
                    }


                    if (index == 1 || index == 100)
                    {

                        repo.ComLabstyleDarioandroid.Linear1.SignUpDiabetesTypeSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Text12.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 2 || index == 100)
                    {

                        repo.ComLabstyleDarioandroid.Linear1.SignUpDiabetesTypeSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Text1.Touch();
                        Delay.Milliseconds(300);
                    }


                    if (index == 3 || index == 100)
                    {

                        repo.ComLabstyleDarioandroid.Linear1.SignUpDiabetesTypeSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Text13.Touch();
                        Delay.Milliseconds(300);
                    }


                    Report.Log(ReportLevel.Info, "     Selecting diabet type process completed succesfuly.");
                    return (1);

                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "Selecting Diabet Type failed!!!");
                    return (0);
                }
            }

            /// <summary>
            /// REGISTRATION menu -Select Country Phone Code from menu
            /// </summary>
            /// <param name="index">index of item starts with-0, default 100- means -all</param>
            /// <returns></returns>
            public int SelectCountryCode(int index = 100)
            {
                Report.Log(ReportLevel.Info, "     Start selecting country code process...  index-" + index);

                try
                {

                    if (index == 0 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Self.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 1 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear1.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 2 || index == 100)
                    {

                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Self.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 3 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear2.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 4 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear3.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 5 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear4.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 6 || index == 100)
                    {
                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear5.Touch();
                        Delay.Milliseconds(300);
                    }

                    if (index == 7 || index == 100)
                    {

                        repo.ComLabstyleDarioandroid.CountryPhonePrefixSpinner.Touch();
                        Delay.Milliseconds(300);

                        repo.ComLabstyleDarioandroid.FormNone.Linear6.Touch();
                        Delay.Milliseconds(300);
                    }

                    //... the list is not completed!!!!!!!!!!!!

                    Report.Log(ReportLevel.Info, "     Selecting country code process completed succesfully.");
                    return (1);
                }
                catch
                {
                    Report.Log(ReportLevel.Failure, "!!!Selecting Country Code failed!!!");
                    return (0);
                }
            }

            public int TapSetingsAcountInformation()
            {
                try
                {
                    Report.Log(ReportLevel.Info, "     Starting tapping Acount Information...");
                    repo.ComLabstyleDarioandroid.TabDarioActivity.Arrow1.Touch();
                    Delay.Milliseconds(3000);//important!!!

                    /*
                    repo.SearchTimeout = CONST.SEARCH_TIMEOUT;
                    repo.ParentFolder.SearchTimeout = CONST.SEARCH_TIMEOUT;
                    */

                    repo.ComLabstyleDarioandroid.TabDarioActivity.ACCOUNTINFORMATION.Touch();
                    Delay.Milliseconds(300);
                    

                    Report.Log(ReportLevel.Info, "     Starting tapping Acount Information completed succesfully.");
                    return (1);

                }
                catch
                {
                    try
                    {
                        /*
                        repo.SearchTimeout = CONST.SEARCH_TIMEOUT;
                        repo.ParentFolder.SearchTimeout = CONST.SEARCH_TIMEOUT;
                        */
                        
                        
                        repo.ComLabstyleDarioandroid.TabDarioActivity.ACCOUNTINFORMATION1.Touch(Location.CenterLeft);
                        Delay.Milliseconds(300);

                        Report.Log(ReportLevel.Info, "     Starting tapping Acount Information completed succesfully.");
                        return (1);
                    }
                    catch
                    {
                        try
                        {
                            /*
                            repo.SearchTimeout = CONST.SEARCH_TIMEOUT;
                            repo.ParentFolder.SearchTimeout = CONST.SEARCH_TIMEOUT;
                            */
                            repo.ComLabstyleDarioandroid.TabDarioActivity.Relative.Touch(Location.CenterLeft);
                            Delay.Milliseconds(300);

                            /*
                             repo.ComLabstyleDarioandroid.TabDarioActivity.Relative1.Touch();
                             Delay.Milliseconds(300);
                              */



                            Report.Log(ReportLevel.Info, "     Starting tapping Acount Information completed succesfully.");
                            return (1);

                        }
                        catch
                        {
                            Report.Log(ReportLevel.Failure, "Tap -Select Acoutn Information- Failed!!!");
                            return (0);
                        }
                    }

                }
            }
        }


        



        /// <summary>
        /// Holds an instance of the test1Repository repository.
        /// </summary>
        public static test1Repository repo = test1Repository.Instance;

        static Recording1 instance = new Recording1();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Recording1()
        {
           
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Recording1 Instance
        {
            get { return instance; }
        }

#region Variables

        

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        
        void ITestModule.Run()
        {
            while (true)
            {
                Dario test1 = new Dario();
                test1.SetDefaults();


                test1.StartApp(CONST.CONNECTED_DEVICE_NAME/*,false*/);

           
                test1.LeftGesture();

                test1.SignUp(CONST.SIGN_UP_EMAIL, CONST.PASSWORD);


                test1.LogIn(CONST.EMAIL, CONST.PASSWORD);


                test1.TapPLUS();

                test1.TapAdd();

                test1.AddManualValue(CONST.MANAUL_VALUE);

                test1.ClosePopUpMenu();

                test1.LogOut();

    

            }
            
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
