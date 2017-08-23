/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* mergeTwoLists(struct ListNode* l1, struct ListNode* l2) {
    struct ListNode* head = malloc(sizeof(struct ListNode));
    head->val = INT_MIN;
    struct ListNode* tracker = head;
    //head = (l1->val > l2->val) ? l2: l1;

    while(l1 != NULL && l2 != NULL)
    {
        
        if(l1->val > l2->val)
        {
            tracker->next = l2;
            l2 = l2->next;
        }
        else
        {
            tracker->next = l1;
            l1 = l1->next;
        }
        tracker = tracker->next;
    }
    if(l1 == NULL)
    {
        tracker->next = l2;
    }
    else
    {
        tracker->next = l1;
    }
    return head->next;
}