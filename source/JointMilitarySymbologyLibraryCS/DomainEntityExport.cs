﻿/* Copyright 2014 Esri
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JointMilitarySymbologyLibrary
{
    public class DomainEntityExport : EntityExport, IEntityExport
    {
        // The class that provides column headers and a constructed line or row of
        // comma separated text containing coded domain values for a given SymbolSet
        // and Entity (type and substype) within that SymbolSet.
 
        public DomainEntityExport(ConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        string IEntityExport.Headers
        {
            get { return "Name,Value"; }
        }

        string IEntityExport.Line(SymbolSet ss,
                                  SymbolSetEntity e,
                                  SymbolSetEntityEntityType eType,
                                  SymbolSetEntityEntityTypeEntitySubType eSubType)
        {
            string code = Convert.ToString(ss.SymbolSetCode.DigitOne) + Convert.ToString(ss.SymbolSetCode.DigitTwo);

            code = code + Convert.ToString(e.EntityCode.DigitOne) + Convert.ToString(e.EntityCode.DigitTwo);

            if (eType != null)
            {
                code = code + Convert.ToString(eType.EntityTypeCode.DigitOne) + Convert.ToString(eType.EntityTypeCode.DigitTwo);
            }
            else
                code = code + "00";

            if (eSubType != null)
            {
                code = code + Convert.ToString(eSubType.EntitySubTypeCode.DigitOne) + Convert.ToString(eSubType.EntitySubTypeCode.DigitTwo);
            }
            else
                code = code + "00";

            return BuildEntityItemName(ss, e, eType, eSubType) + "," + code;
        }
    }
}
