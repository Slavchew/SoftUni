import { isPlatformBrowser, isPlatformServer } from '@angular/common';
import { Injectable, Provider, PLATFORM_ID } from '@angular/core';

interface IStorage {
    setItem<T>(key: string, item : T): T,
    getItem<T>(key: string): T | null,
}

export class StorageService implements IStorage {
    setItem<T>(key: string, item: T): T {
        return item;
    }
    getItem<T>(key: string): T | null {
        return null;
    }
}

export function storageFactory(platformId: string): any {
    if (isPlatformBrowser(platformId)) {
        return new BrowserStorage();
    }

    if (isPlatformServer(platformId)) {
        return new ServerStorage();
    }

    throw new Error('No implementation for this provider: ' + platformId)
}

export const storageServiceProvider: Provider = {
    provide: StorageService,
    useFactory: storageFactory,
    deps: [PLATFORM_ID]
} 

export class BrowserStorage {
    localStorage = localStorage;

    setItem<T>(key: string, item : T): T {
        const str = typeof item === 'string' ? item : JSON.stringify(item);
        this.localStorage.setItem(key, str);
        return item;
    }

    getItem<T>(key: string): T | null {
        let item;
        const tmp = this.localStorage.getItem(key);
        if (!tmp) {
            return null;
        }
        try {
            item = JSON.parse(tmp!);
        } catch {
            item = tmp;
        }
        return item;
    }
}

export class ServerStorage {
    localStorage = {
        data: {},
        setItem<T>(key: string, item : T): void {
            Object.assign(this.data, {key, item});
        },
        getItem<T>(key: string): T {
            return Object.entries(this.data).find(x => x[0] == key)?.[1] as any;
        }
    }

    setItem<T>(key: string, item : T): T {
        const str = typeof item === 'string' ? item : JSON.stringify(item);
        this.localStorage.setItem(key, str);
        return item;
    }

    getItem<T>(key: string): T | null {
        let item;
        const tmp = this.localStorage.getItem(key) as any;
        if (!tmp) {
            return null;
        }
        try {
            item = JSON.parse(tmp);
        } catch {
            item = tmp;
        }
        return item;
    }
}
