// detail: https://atcoder.jp/contests/abc198/submissions/21722591
#include <iostream>
#include <algorithm>
#include <vector>
#include <array>
#include <set>

using namespace std;

template<typename T>
struct Component {
  int i;
  int j;
  T elem;
  Component(){}
  Component(int i, int j, T elem):i(i),j(j),elem(elem){}
};

template<size_t mat_size, uint32_t mod> // mod は 2^30 以下
struct ModMatrix {
  using SparseMat = vector<Component<uint64_t>>;
  using Vector = array<uint64_t, mat_size>;

  array<uint64_t, mat_size * mat_size> d;

  uint64_t& at(const size_t i, const size_t j) { return d[i * mat_size + j]; }
  const uint64_t& at(const size_t i, const size_t j) const { return d[i * mat_size + j]; }
  void sparse_pow(long long n, ModMatrix& res, SparseMat& sparse_notation) {
    if (n == 0) {
      res = identity();
      return;
    }
    ModMatrix tmp;
    sparse_pow(n / 2, tmp, sparse_notation);
    if (n & 1) {
      ModMatrix tmp2;
      mul(tmp, tmp, tmp2);
      mul(tmp2, sparse_notation, res);
    }
    else {
      mul(tmp, tmp, res);
    }
  }
  void sparse_pow(long long n, ModMatrix& res) {
    SparseMat sparse;
    asSparse(sparse);
    sparse_pow(n, res, sparse);
  }
  ModMatrix sparse_pow(long long n) {
    ModMatrix res;
    sparse_pow(n, res);
    return res;
  }
  void pow(long long n, ModMatrix& res) {
    ModMatrix a; a.d = d;
    res = identity();
    ModMatrix tmp;
    while (true) {
      if (n & 1) {
        mul(res, a, tmp); // res = mul(res, a);
        swap(res, tmp);
      }
      if (!(n >>= 1)) break;
      mul(a, a, tmp);
      swap(a, tmp);
    }
  }
  ModMatrix pow(long long n) {
    ModMatrix res;
    pow(n, res);
    return res;
  }
  void asSparse(SparseMat& res) {
    res.clear();
    for (int i = 0; i < mat_size; i++) {
      for (int j = 0; j < mat_size; j++) {
        if (at(i, j)) res.emplace_back(i, j, at(i, j));
      }
    }
  }
  SparseMat asSparse() {
    SparseMat res;
    asSparse(res);
    return res;
  }

  // 参考: https://ameblo.jp/morimoridiary/entry-10630261646.html
  static void mul(const ModMatrix& A, const ModMatrix& B, ModMatrix& res) {
    const int BLOCK = 16;
    uint64_t temp = 0, * ptemp = 0, partSum[8] = {};
    res.d.fill(0);
    const uint64_t* ptempc = 0;
    for (int i0 = 0; i0 < mat_size; i0 += BLOCK) {
      for (int j0 = 0; j0 < mat_size; j0 += BLOCK) {
        for (int k0 = 0; k0 < mat_size; k0 += BLOCK) {
          for (int i = i0; i < i0 + BLOCK; i++) {
            for (int j = j0; j < j0 + BLOCK; j += 8) {
              partSum[0] = 0;
              partSum[1] = 0;
              partSum[2] = 0;
              partSum[3] = 0;
              partSum[4] = 0;
              partSum[5] = 0;
              partSum[6] = 0;
              partSum[7] = 0;
              ptempc = &B.d[k0 * mat_size + j];
              for (int k = k0; k < k0 + BLOCK; k++) {
                temp = A.d[i * mat_size + k];
                partSum[0] += temp * ptempc[0];
                partSum[1] += temp * ptempc[1];
                partSum[2] += temp * ptempc[2];
                partSum[3] += temp * ptempc[3];
                partSum[4] += temp * ptempc[4];
                partSum[5] += temp * ptempc[5];
                partSum[6] += temp * ptempc[6];
                partSum[7] += temp * ptempc[7];
                ptempc = &ptempc[mat_size];
              }
              ptemp = &res.d[i * mat_size + j];
              (ptemp[0] += partSum[0]) %= mod;
              (ptemp[1] += partSum[1]) %= mod;
              (ptemp[2] += partSum[2]) %= mod;
              (ptemp[3] += partSum[3]) %= mod;
              (ptemp[4] += partSum[4]) %= mod;
              (ptemp[5] += partSum[5]) %= mod;
              (ptemp[6] += partSum[6]) %= mod;
              (ptemp[7] += partSum[7]) %= mod;
            }
          }
        }
      }
    }
  }
  static ModMatrix mul(const ModMatrix& A, const ModMatrix& B) {
    ModMatrix res;
    mul(A, B, res);
    return res;
  }
  static void mul(const ModMatrix& A, const SparseMat& B, ModMatrix& res) {
    res.d.fill(0);
    for (auto&& [j, k, elem] : B) {
      for (int i = 0; i < mat_size; i++) {
        res.at(i, k) += A.at(i, j) * elem;
        res.at(i, k) %= mod;
      }
    }
  }
  static ModMatrix mul(const ModMatrix& A, const SparseMat& B) {
    ModMatrix res;
    mul(A, B, res);
    return res;
  }

  static void mul(const ModMatrix& A, const Vector& B, Vector& res) {
    for (int i = 0; i < mat_size; i++) {
      for (int j = 0; j < mat_size; j++) {
        auto mul = A.at(i, j) * B[j];
        res[i] += mul;
      }
    }
  }
  static Vector mul(const ModMatrix& A, const Vector& B) {
    Vector res;
    mul(A, B, res);
    return res;
  }
  static ModMatrix identity() {
    ModMatrix id{};
    for (int i = 0; i < mat_size; i++) id.at(i, i) = 1;
    return id;
  }
};

//  0
// 1234
//  5
void rotate1(vector<int>& a) {
  auto tmp = a[1];
  a[1] = a[2];
  a[2] = a[3];
  a[3] = a[4];
  a[4] = tmp;
}

void rotate2(vector<int>& a) {
  auto tmp = a[0];
  a[0] = a[2];
  a[2] = a[5];
  a[5] = a[4];
  a[4] = tmp;
}

vector<vector<int>> get_all_rotations(vector<int> a) {
  vector<vector<int>> res{};
  for (int i = 0; i < 4; i++) {
    res.emplace_back(a);
    rotate2(a);
    for (int j = 0; j < 4; j++) {
      res.emplace_back(a);
      rotate1(a);
    }
    rotate2(a); rotate2(a); rotate2(a);
    rotate1(a);
  }
  rotate2(a); rotate2(a);
  for (int j = 0; j < 4; j++) {
    res.emplace_back(a);
    rotate1(a);
  }
  return res;
}

const int block_cnt = 6;
const int block_size = 1 << block_cnt;
const int mat_size = block_cnt * block_size;

const int MOD = 998244353;
using Mat = ModMatrix<mat_size, MOD>;

int main() {
  vector<int> highest_bit_ind(block_size);
  for (int i = 0; i <= block_cnt; i++)
    for (int j = (1 << i) >> 1; j < (1 << i); j++)
      highest_bit_ind[j] = i;

  //    5      4      3      2      1      0
  // [六個前][五個前][四個前][三個前][二個前][一個前]
  Mat mat{};
  auto get_ind = [&](int blockInd, int bit) { return (block_cnt - blockInd - 1) * block_size + bit; };

  for (int block = 0; block < block_cnt; block++) {
    // 今から使う遷移は block+1
    // なので、最高位 bit(1-indexed) が block+1 以下であれば遷移を使用可能

    // operate to cur
    for (int bit = 0; bit < block_size; bit++) {
      if (block + 1 < highest_bit_ind[bit]) continue;
      mat.at(get_ind(0, bit | (1 << block)), get_ind(block, bit)) = 1;
    }

    // shift to prev
    if (block_cnt <= block + 1) continue;
    for (int bit = 0; bit < block_size; bit++) {
      mat.at(get_ind(block + 1, bit), get_ind(block, bit)) = 1;
    }
  }

  Mat::Vector iv;
  iv[get_ind(0, 0)] = 1;

  long long s;
  cin >> s;

  auto res_vec = Mat::mul(mat.sparse_pow(s), iv);

  set<vector<int>> added{};
  set<vector<int>> all_types{};
  for (int b = 0; b < (1 << 5); b++) {
    // 6 6 4 3 3 1 のようなものの並び替えであってほしい
    // 順位として見た場合、タイの場合は一番下の順位
    vector<int> arr(6);
    int curRank = 5;
    for (int i = 6 - 1; i >= 0; i--) {
      if ((b >> i & 1) == 1) curRank = i;
      arr[i] = curRank;
    }
    sort(arr.begin(), arr.end());
    do
    {
      if (added.count(arr)) continue;
      all_types.insert(arr);
      auto all_rotation = get_all_rotations(arr);
      for (auto&& rotated : all_rotation) added.insert(rotated);
    } while (next_permutation(arr.begin(), arr.end()));
  }

  uint64_t res = 0;
  for (auto&& type : all_types) {
    // 6 6 4 3 3 1 は
    // 2+2+3+4+4+5
    // のようなものとして捉えると、
    // 6*2+4*1+3*1+1*1
    // と分解できる。この倍はこれは先程の DP で求めた。
    int bit = 0;
    for (auto&& i : type) bit |= 1 << i;
    res += res_vec[get_ind(0, bit)];
  }
  cout << res % MOD << endl;
}
