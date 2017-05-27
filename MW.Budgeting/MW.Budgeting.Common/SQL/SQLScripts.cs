﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  A replacement for the YNAB4 windows application, should it ever be retired.
 *  See License.txt for the full license.
 *  Copyright (C) 2017 Mephi-Dross
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace MW.Budgeting.Common.SQL
{
    public static class SQLScripts
    {
        #region Table Creation

        public const string CREATE_ENTRY_TABLE =
            @"CREATE TABLE Entry (
                ID VARCHAR(32) PRIMARY KEY  NOT NULL  UNIQUE , 
                Date DateTime,
                Outflow decimal,
                Inflow decimal,
                IsDone bool,
                Account VARCHAR(32),
                Payee VARCHAR(32),
                Category VARCHAR(32)
            );";

        public const string CREATE_CATEGORY_TABLE =
            @"CREATE TABLE Category (
                ID VARCHAR(32) PRIMARY KEY  NOT NULL  UNIQUE , 
                Name VARCHAR(255), 
                IsMasterCategory BOOL, 
                ParentCategory VARCHAR(32)
            )";

        public const string CREATE_PAYEE_TABLE = 
            @"CREATE TABLE Payee (
                ID VARCHAR(32) PRIMARY KEY  NOT NULL  UNIQUE , 
                Name VARCHAR(255), 
                IsActive BOOL
            )";

        public const string CREATE_ACCOUNT_TABLE = 
            @"CREATE TABLE Account (
                ID VARCHAR(32) PRIMARY KEY  NOT NULL  UNIQUE , 
                Name VARCHAR(255), 
                Note VARCHAR(255), 
                IsOffBudget BOOL, 
                IsActive BOOL, 
                Type VARCHAR(255)
            )";

        #endregion

        #region GET-Scripts

        public const string GET_SELECTED_ACCOUNT =
            @"SELECT *
              FROM Account
              WHERE Name = '[NAME]'
              LIMIT 1;
             ";

        public const string GET_ENTRIES_FROM_ACCOUNT =
            @"SELECT *
              FROM Entry
              WHERE Account = [ACCOUNT]";

        #endregion

        #region Insert-Scripts

        public const string INSERT_ACCOUNT =
            @"INSERT INTO Account (ID, Name, Note, IsOffBudget, IsActive, Type)
                VALUES (
                    '[ID]',
                    '[NAME]',
                    '[NOTE]',
                    '[ISOFFBUDGET]',
                    '[ISACTIVE]',
                    '[TYPE]'
                )";

        public const string INSERT_ENTRY =
            @"INSERT INTO Entry (ID, Date, Outflow, Inflow, IsDone, Account, Payee, Category)
                VALUES (
                    '[ID]',
                    '[DATE]',
                    '[OUTFLOW]',
                    '[INFLOW]',
                    '[ISDONE]',
                    '[ACCOUNT]',
                    '[PAYEE]',
                    '[CATEGORY]'
                )";

        #endregion

        #region Update-Scripts

        #endregion
    }
}
