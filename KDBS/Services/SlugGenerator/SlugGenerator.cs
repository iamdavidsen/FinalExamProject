//using System.Text;
//using System.Threading.Tasks;
//using KDBS.Data;
//using Microsoft.EntityFrameworkCore;

//namespace KDBS.Services.SlugGenerator
//{
//    public class SlugGeneratorService : ISlugGeneratorService
//    {
//        private readonly ApplicationDbContext _context;

//        public SlugGeneratorService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<string> GetSlug(Job job)
//        {
//            var slug = GetSlug(job.Title);

//            var index = 0;
//            var slugEnd = "";
//            while (true)
//            {
//                var end = slugEnd;
//                var oldSlug = await _context.Jobs.FirstOrDefaultAsync(j => j.Slug == slug + end);

//                if (oldSlug != null)
//                {
//                    index += 1;
//                    slugEnd = $"-{index}";
//                }
//                else
//                {
//                    return slug + slugEnd;
//                }
//            }
//        }

//        private string GetSlug(string title, int maxlength = 80)
//        {
//            if (title == null)
//            {
//                return string.Empty;
//            }

//            var length = title.Length;
//            var prevdash = false;
//            var stringBuilder = new StringBuilder(length);

//            for (var i = 0; i < length; ++i)
//            {
//                var c = title[i];
//                switch (c)
//                {
//                    case >= 'a' and <= 'z':
//                    case >= '0' and <= '9':
//                        stringBuilder.Append(c);
//                        prevdash = false;
//                        break;
//                    case >= 'A' and <= 'Z':
//                        // tricky way to convert to lower-case
//                        stringBuilder.Append((char)(c | 32));
//                        prevdash = false;
//                        break;
//                    case ' ':
//                    case ',':
//                    case '.':
//                    case '/':
//                    case '\\':
//                    case '-':
//                    case '_':
//                    case '=':
//                        {
//                            if (!prevdash && stringBuilder.Length > 0)
//                            {
//                                stringBuilder.Append('-');
//                                prevdash = true;
//                            }

//                            break;
//                        }
//                    default:
//                        {
//                            if (c >= 128)
//                            {
//                                var previousLength = stringBuilder.Length;

//                                stringBuilder.Append(RemapInternationalCharToAscii(c));

//                                if (previousLength != stringBuilder.Length)
//                                {
//                                    prevdash = false;
//                                }
//                            }

//                            break;
//                        }
//                }

//                if (i == maxlength)
//                {
//                    break;
//                }
//            }

//            return prevdash
//                ? stringBuilder.ToString().Substring(0, stringBuilder.Length - 1)
//                : stringBuilder.ToString();
//        }

//        private string RemapInternationalCharToAscii(char character)
//        {
//            var s = character.ToString().ToLowerInvariant();
//            if ("àåáâäãåąā".Contains(s))
//            {
//                return "a";
//            }

//            if ("èéêëę".Contains(s))
//            {
//                return "e";
//            }

//            if ("ìíîïı".Contains(s))
//            {
//                return "i";
//            }

//            if ("òóôõöøő".Contains(s))
//            {
//                return "o";
//            }

//            if ("ùúûüŭů".Contains(s))
//            {
//                return "u";
//            }

//            if ("çćčĉ".Contains(s))
//            {
//                return "c";
//            }

//            if ("żźž".Contains(s))
//            {
//                return "z";
//            }

//            if ("śşšŝ".Contains(s))
//            {
//                return "s";
//            }

//            if ("ñń".Contains(s))
//            {
//                return "n";
//            }

//            if ("ýÿ".Contains(s))
//            {
//                return "y";
//            }

//            if ("ğĝ".Contains(s))
//            {
//                return "g";
//            }

//            if (character == 'ř')
//            {
//                return "r";
//            }

//            if (character == 'ł')
//            {
//                return "l";
//            }

//            if ("đð".Contains(s))
//            {
//                return "d";
//            }

//            if (character == 'ß')
//            {
//                return "ss";
//            }

//            if (character == 'Þ')
//            {
//                return "th";
//            }

//            if (character == 'ĥ')
//            {
//                return "h";
//            }

//            if (character == 'ĵ')
//            {
//                return "j";
//            }

//            return s;
//        }
//    }
//}
