using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6
{
    public class NoBadWords : ValidationAttribute
    {
        private HashSet<String> BadWordDictionary { get; set; }

        public NoBadWords() : base()
        {
            BadWordDictionary = new HashSet<string> { "f*ck", "abc", "badword" };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var text = (String) value;            for (var i = 0; i < text.Length; i++)
            {
                foreach (var badWord in BadWordDictionary)
                {
                    int len = badWord.Length;

                    if (len > text.Length - i)
                    {
                        continue;
                    }

                    bool ok = true;
                    for (var k = i; k < i + len; k++)
                    {
                        if (text[k] != badWord[k - i])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        return new ValidationResult("Bad word used");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}