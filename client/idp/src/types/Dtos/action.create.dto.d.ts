declare interface ActionCreateDto {
    name: string;

    endDate: Date

    objective: number

    userId: number
    /**
     * The description of the category. It should be a short description of the
     * category and should not exceed 250 characters.
     */
    description: string;
}
