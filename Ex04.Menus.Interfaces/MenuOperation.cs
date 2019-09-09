using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuOperation : MenuItem
    {
        private IMenuOperation m_MenuOperation;

        internal MenuOperation(IMenuOperation i_MenuOperation, string i_OperationDescription) : base(i_OperationDescription)
        {
            m_MenuOperation = i_MenuOperation;
            Description = i_OperationDescription;
        }

        internal override void Show()
        {
            m_MenuOperation.Operate();
        }
    }
}
