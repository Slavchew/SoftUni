import { Component } from "@angular/core";

interface Game {
    title: string;
    price: number;
    img: string;
}

@Component({
    selector: 'su-game',
    // template: '<h2>This is game component</h2>',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})

export class GameComponent {
    shouldPriceBeColorized: boolean = false;

    games: Game[] = [
        { title: 'Minecraft', price: 10, img: 'https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg' },
        { title: 'CS:GO', price: 25, img: 'https://estnn.com/wp-content/uploads/2022/05/CS-GO-wallpaper-HD-art_hue3ed7aeab8fceb3ccf3a35de14fc82fb_1114369_1920x1080_resize_q75_lanczos.jpg' },
        { title: 'League of Legends', price: 0, img: 'https://cdn.vox-cdn.com/thumbor/UehyoNzYoIR5ZJDrvHjDAZhmkaI=/0x0:1920x1080/1400x933/filters:focal(1030x331:1336x637):no_upscale()/cdn.vox-cdn.com/uploads/chorus_image/image/65632309/jbareham_191158_ply0958_decade_lolengends.0.jpg' },
    ]

    handleExpandContentClick(): void {
        this.shouldPriceBeColorized = !this.shouldPriceBeColorized;
    }
}