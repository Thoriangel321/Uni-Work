#pragma once

class IDuplicate {
public:
    virtual void FindDuplicate() = 0;
    virtual ~IDuplicate() = default;
};