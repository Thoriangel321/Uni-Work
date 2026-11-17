using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.BLL.Interfaces
{
    public interface IOnlineLearner
    {
        string StudyOnline(bool hasInternet);
    }
}