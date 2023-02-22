declare interface ActionCreateDto {
    name: string;

    startDate: Date;

    endDate: Date

    objectiveId: number

    /**
     * The description of the action. It should be a short description of the
     * action and should not exceed 250 characters.
     */
    description: string;

    progress: number
}
