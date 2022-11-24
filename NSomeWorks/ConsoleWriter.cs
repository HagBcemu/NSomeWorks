using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        private NoteContact _noteContact;

        private Language _language = Language.English;
        public ConsoleWriter()
        {
            _noteContact = new NoteContact();
            _noteContact.AddListContact(ContactCreater.GetContacts());
        }

        public void ShowConsole()
        {
            ShowNoteContact();
            ShowControlPanelNoteContact();
        }

        void ShowNoteContact()
        {
            Console.Clear();
            Console.WriteLine("Контакты: ");
            List<GroupContact> groupContact = _noteContact.GetAllSortContact(_language);
            foreach (var group in groupContact)
            {
                Console.WriteLine(group.GroupName + ":_______");
                foreach (var contact in group.GetListContact())
                {
                    Console.WriteLine("\t" + contact.Name + " - " + contact.PhoneNumber);
                }
            }

            Console.WriteLine("\nВведите номер команды:");
            Console.WriteLine("1 - для добавления контакта");
            Console.WriteLine("2 - для смены языка на Английский");
            Console.WriteLine("3 - для смены языка на Украинский");
            Console.WriteLine("4 - для выхода");
        }

        void ShowControlPanelNoteContact()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose == 1)
                    {
                        Console.WriteLine("Введите через /");
                        string userInput = Console.ReadLine();
                        string[] inputSlit = userInput.Split("/");
                        if (inputSlit.Length >= 2)
                        {
                            if (inputSlit[0] != string.Empty && inputSlit[1] != string.Empty)
                            {
                                _noteContact.AddContact(inputSlit[0], inputSlit[1]);
                                ShowConsole();
                            }
                            else
                            {
                                ShowNoteContact();
                                Console.WriteLine("Что то не так. Введите заново номер команды");
                            }
                        }
                        else
                        {
                            ShowNoteContact();
                            Console.WriteLine("Что то не так. Введите заново номер команды");
                        }
                    }

                    if (numberChose == 2)
                    {
                        _language = Language.English;
                        ShowNoteContact();
                    }

                    if (numberChose == 3)
                    {
                        _language = Language.Ukrainian;
                        ShowNoteContact();
                    }

                    if (numberChose == 4)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }
    }
}
