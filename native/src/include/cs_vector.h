#pragma once

#include <types.h>
#include <vector>

#include "exp.h"

EXP void ExportVector(std::vector<u8>* handle, u8** dst, int* dst_len);

EXP void FreeVector(std::vector<u8>* handle);