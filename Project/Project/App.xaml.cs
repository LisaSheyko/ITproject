﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project
{
    public partial class App : Application
    {
        // права пользователя, имя и uk ученика/учителя, выбранная задача/тема, выбранный класс
        public string grant_ccode, child_name, child_uk, master_uk, master_name, task_uk, theory_uk, class_num, class_let;
        public bool TaskMode;
    }
}
