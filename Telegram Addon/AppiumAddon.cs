﻿using G1ANT.Language;


namespace G1ANT.Addon.Telegram

{
    [Addon(Name = "Telegram", Tooltip = "This Addon is used to automatise mobile operating systems.")]
    [Copyright(Author = "G1ANT Robot LTD", Copyright = "G1ANT Robot LTD", Email = "support@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "appium", Tooltip = "Appium wraper.")]
    public class AppiumAddon : Language.Addon
    {

        public override void Check()
        {
            base.Check();
            // Check integrity of your Addon
            // Throw exception if this Addon needs something that doesn't exists
        }

        public override void LoadDlls()
        {
            base.LoadDlls();
            // All dlls embeded in resources will be loaded automatically,
            // but you can load here some additional dlls:

            // Assembly.Load("...")
        }

        public override void Initialize()
        {
            base.Initialize();
            // Insert some code here to initialize Addon's objects
        }

        public override void Dispose()
        {
            base.Dispose();
            // Insert some code here which will dispose all unecessary objects when this Addon will be unloaded
        }
    }
}