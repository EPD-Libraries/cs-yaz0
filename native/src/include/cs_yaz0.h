#pragma once

#include <types.h>
#include <vector>

#include "exp.h"

EXP std::vector<u8>* Compress(u8* src, u32 src_len, u32 alignment, int level);