#include "cs_vector.h"

void ExportVector(std::vector<u8>* handle, u8** dst, int* dst_len) {
  *dst = handle->data();
  *dst_len = handle->size();
}

void FreeVector(std::vector<u8>* handle) {
  delete handle;
}