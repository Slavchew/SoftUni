import { IBase } from "./base";
import { IUser } from "./user";
import { ITheme } from "./theme";

export interface IPost extends IBase {
    likes: string[];
    text: string;
    userId: IUser,
    themeId: ITheme,
}