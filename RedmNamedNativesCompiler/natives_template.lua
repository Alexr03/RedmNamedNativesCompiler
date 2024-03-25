local hashes = {
${hash_data}
}

for name, hash in pairs(hashes) do
    _G[name] = function(...)
        return Citizen.InvokeNative(hash, ...)
    end
end