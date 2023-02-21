declare interface ObjectiveCreateDto {
    name: string;

    idpId: number;

    categoryId: number;

    status: statusType;

    startDate: Date;

    endDate: Date;
}
