using System.Collections.Generic;

public static class ContentsBase
{
    public static List<Content> GetContents()
    {
        return new List<Content>
        { 
            // ENTRETENIMENTO
            new Content
            {
                title = "Meme de Gatos",
                tag = Tag.Entertainment,
                type = Type.Image,
            },
            new Content
            {
                title = "Cartaz de Filme",
                tag = Tag.Entertainment,
                type = Type.Image,
            },
            new Content
            {
                title = "Foto de Férias",
                tag = Tag.Entertainment,
                type = Type.Image,
            },
            new Content
            {
                title = "Trecho de Filme",
                tag = Tag.Entertainment,
                type = Type.Video,
            },
            new Content
            {
                title = "Video Curto",
                tag = Tag.Entertainment,
                type = Type.Video,
            },
            new Content
            {
                title = "Clipe Musical",
                tag = Tag.Entertainment,
                type = Type.Video,
            },
            new Content
            {
                title = "Post de Lifestyle",
                tag = Tag.Entertainment,
                type = Type.Text,
            },
            new Content
            {
                title = "Review de Filme",
                tag = Tag.Entertainment,
                type = Type.Text,
            },
            new Content
            {
                title = "Thread Viral",
                tag = Tag.Entertainment,
                type = Type.Text,
            },

            //EDUCATION
            new Content
            {
                title = "Mapa Mental",
                tag = Tag.Education,
                type = Type.Image
            },
            new Content
            {
                title = "Infográfico Científico",
                tag = Tag.Education,
                type = Type.Image
            },
            new Content
            {
                title = "Gráfico Estatístico",
                tag = Tag.Education,
                type = Type.Image
            },
            new Content
            {
                title = "Aula Matemática",
                tag = Tag.Education,
                type = Type.Video,
            },
            new Content
            {
                title = "Curiosidade Histórica",
                tag = Tag.Education,
                type = Type.Video,
            },
            new Content
            {
                title = "Documentário",
                tag = Tag.Education,
                type = Type.Video,
            },
            new Content
            {
                title = "Pesquisa Universitária",
                tag = Tag.Education,
                type = Type.Text,
            },
            new Content
            {
                title = "Artigo Científico",
                tag = Tag.Education,
                type = Type.Text,
            },
            new Content
            {
                title = "Resumo Educacional",
                tag = Tag.Education,
                type = Type.Text,
            },

            //TECNOLOGIA
            new Content
            {
                title = "Interface de App",
                tag = Tag.Tecnology,
                type = Type.Image,
            },
            new Content
            {
                title = "Diagrama de Sistema",
                tag = Tag.Tecnology,
                type = Type.Image,
            },
            new Content
            {
                title = "Print de Código",
                tag = Tag.Tecnology,
                type = Type.Image,
            },
            new Content
            {
                title = "Curso de Programação",
                tag = Tag.Tecnology,
                type = Type.Video,
            },
            new Content
            {
                title = "Evolução dos Gráficos",
                tag = Tag.Tecnology,
                type = Type.Video,
            },
            new Content
            {
                title = "Review de Hardware",
                tag = Tag.Tecnology,
                type = Type.Video,
            },
            new Content
            {
                title = "Código Aberto",
                tag = Tag.Tecnology,
                type = Type.Text,
            },
            new Content
            {
                title = "Documentação Técnica",
                tag = Tag.Tecnology,
                type = Type.Text,
            },
            new Content
            {
                title = "Discussão de Fórum",
                tag = Tag.Tecnology,
                type = Type.Text,
            }
        };   
    }
}
