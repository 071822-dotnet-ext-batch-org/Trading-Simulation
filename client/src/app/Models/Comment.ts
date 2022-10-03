export interface Comment {
    commentID: string;
    fk_UserID: string;
    fk_PostID: string;
    content: string;
    likes: number;
    dateCreated: Date;
    dateModified: Date;
}