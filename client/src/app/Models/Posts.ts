export interface Post {
    postID: string;
    fk_UserID: string;
    content: string;
    likes: number;
    privacyLevel: number;
    dateCreated: Date;
    dateModified: Date;
}