export interface News {
    uuid: string,
    title: string,
    description: string,
    keywords: string,
    snippet: string,
    url: string,
    image_url: string,
    language: string,
    published_at: string,
    source: string,
    relevance_score: number,
    entities:string, 
}