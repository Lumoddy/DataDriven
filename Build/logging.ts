
export function log(
    type: "info" | "success" | "warning" | "error",
    ...message: [unknown, ...unknown[]]): void
{
    let icon;
    switch (type)
    {
        case "success":
            icon = "\x1B[1;32m---";
            break;
        case "warning":
            icon = "\x1B[1;33m/!\\";
            break;
        case "error":
            icon = "\x1B[1;31m{!}";
            break;
        default:
            icon = "\x1B[1;36m???";
            break;
    }

    const date = new Date(Date.now());
    console.log(
        `\x1B[1;37m[ ${icon}`,
        `\x1B[1;37m${
            date.getHours().toString().padStart(2, "0")}:${
            date.getMinutes().toString().padStart(2, "0")}:${
            date.getSeconds().toString().padStart(2, "0")}.${
            date.getMilliseconds().toString().padStart(4, "0")} \x1B[1;37m]\x1B[0m`,
        ...message);
}